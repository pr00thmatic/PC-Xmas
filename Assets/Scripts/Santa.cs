using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Santa : NonPersistentSingleton<Santa> {
  public event System.Action onFall;

  [Header("Configuration")]
  public float timeToReturnToBoth = 1;
  public float tripTime = 0.25f;
  public float[] maxMetersByStepPerFall = new float[] { 10, 8, 6, 4, 2, 1 };
  public float[] accelerationByStepPerFall = new float[] { 5, 4, 3, 2, 1, 0.5f };

  [Header("Information")]
  public float metersByStep = 0.2f;
  public SmoothFloat progress;
  public static float Progress { set => Instance.progress.target = value; get => Instance.progress.current;  } // in meters o__O
  public int leg = 3; // 0 is left, 1 is right, 3 is both, -1 is none xD
  public float timeSinceStroke = Mathf.Infinity;
  public bool advancedThisFrame = false;
  public float elapsedTripTime = 0;
  public int currentFallLevel = 0;
  public float Acceleration { get {
      return accelerationByStepPerFall[Mathf.Min(accelerationByStepPerFall.Length-1, Mathf.Max(0, currentFallLevel))];
    } }
  public float MaxMetersByStep { get {
      return maxMetersByStepPerFall[Mathf.Min(maxMetersByStepPerFall.Length-1, Mathf.Max(0, currentFallLevel))];
    } }

  [Header("Initialization")]
  public Animator animator;

  void Update () {
    if (leg == -1) {
      elapsedTripTime += Time.deltaTime;
      metersByStep = 0;
      if (elapsedTripTime >= tripTime) {
        elapsedTripTime = 0;
        leg = 3;
      } else {
        return;
      }
    }

    advancedThisFrame = false;
    if (((leg == 0 || leg == 3) && Input.GetKeyDown(KeyCode.D)) ||
        ((leg == 1 || leg == 3) && Input.GetKeyDown(KeyCode.A))) {
      metersByStep = Mathf.Min(MaxMetersByStep, metersByStep + Acceleration);
      Progress += metersByStep;
      leg = leg == 3? (Input.GetKeyDown(KeyCode.A)? 0: 1): (leg+1) % 2;
      advancedThisFrame = true;
    }

    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) {
      timeSinceStroke = 0;
      if (!advancedThisFrame) {
        if (leg != -1) {
          if (currentFallLevel < maxMetersByStepPerFall.Length) {
            currentFallLevel++;
          }
          onFall?.Invoke();
        }
        leg = -1;
      }
    }

    if (!advancedThisFrame) {
      metersByStep = Mathf.Max(0, metersByStep - (MaxMetersByStep / 0.5f) * Time.deltaTime);
    }
    if (timeSinceStroke >= timeToReturnToBoth && leg != 3) {
      leg = 3;
      metersByStep = 0;
    }

    progress.Update();
    animator.SetInteger("leg", leg);
    animator.SetFloat("fucked up", 0.9f * (Mathf.Max(0, currentFallLevel) / (float) accelerationByStepPerFall.Length));
    timeSinceStroke += Time.deltaTime;
  }
}
