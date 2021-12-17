using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Santa : NonPersistentSingleton<Santa> {
  public event System.Action onFall;

  [Header("Configuration")]
  public float timeToReturnToBoth = 1;
  public float tripTime = 0.25f;
  public float[] metersByStepPerFall = new float[] { 5, 4, 3, 2, 1, 0.5f };

  [Header("Information")]
  public float metersByStep = 0.2f;
  public SmoothFloat progress;
  public static float Progress { set => Instance.progress.target = value; get => Instance.progress.current;  } // in meters o__O
  public int leg = 3; // 0 is left, 1 is right, 3 is both, -1 is none xD
  public float timeSinceStroke = Mathf.Infinity;
  public bool advancedThisFrame = false;
  public float elapsedTripTime = 0;
  public int currentFallLevel = 0;

  [Header("Initialization")]
  public Animator animator;

  void OnEnable () {
    metersByStep = metersByStepPerFall[currentFallLevel];
  }

  void Update () {
    if (leg == -1) {
      elapsedTripTime += Time.deltaTime;
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
      Progress += metersByStep;
      leg = leg == 3? (Input.GetKeyDown(KeyCode.A)? 0: 1): (leg+1) % 2;
      advancedThisFrame = true;
    }

    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) {
      timeSinceStroke = 0;
      if (!advancedThisFrame) {
        if (leg != -1) {
          if (currentFallLevel < metersByStepPerFall.Length) {
            currentFallLevel++;
            metersByStep = metersByStepPerFall[currentFallLevel];
          }
          onFall?.Invoke();
        }
        leg = -1;
      }
    }

    if (timeSinceStroke >= timeToReturnToBoth && leg != 3) {
      leg = 3;
    }

    progress.Update();
    animator.SetInteger("leg", leg);
    timeSinceStroke += Time.deltaTime;
  }
}
