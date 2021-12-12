using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Santa : MonoBehaviour {
  [Header("Configuration")]
  public float metersByStep = 0.2f;
  public float timeToReturnToBoth = 1;
  public float tripTime = 0.25f;

  [Header("Information")]
  public float progress = 0; // in meters o__O
  public int leg = 3; // 0 is left, 1 is right, 3 is both, -1 is none xD
  public float targetProgress = 0;
  public float progressToTargetVelocity = 0;
  public float progressToTargetSmoothTime = 0.1f;
  public float timeSinceStroke = Mathf.Infinity;
  public bool advancedThisFrame = false;
  public float elapsedTripTime = 0;

  [Header("Initialization")]
  public Animator animator;

  void OnEnable () {
    targetProgress = progress;
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
    if ((leg == 0 || leg == 3) && Input.GetKeyDown(KeyCode.D) || (leg == 1 || leg == 3) && Input.GetKeyDown(KeyCode.A)) {
      targetProgress += metersByStep;
      leg = (leg+1) % 2;
      advancedThisFrame = true;
    }

    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) {
      timeSinceStroke = 0;
      if (!advancedThisFrame) {
        leg = -1;
      }
    }

    if (timeSinceStroke >= timeToReturnToBoth && leg != 3) {
      leg = 3;
    }

    progress = Mathf.SmoothDamp(progress, targetProgress,
                                ref progressToTargetVelocity,
                                progressToTargetSmoothTime);
    animator.SetInteger("leg", leg);
    timeSinceStroke += Time.deltaTime;
  }
}
