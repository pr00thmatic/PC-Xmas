using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Santa : MonoBehaviour {
  [Header("Configuration")]
  public float metersByStep = 0.2f;
  public float timeToReturnToBoth = 1;
  public float tripTime = 0.25f;

  [Header("Information")]
  public SmoothFloat progress;
  public float Progress { set => progress.target = value; get => progress.current;  } // in meters o__O
  public int leg = 3; // 0 is left, 1 is right, 3 is both, -1 is none xD
  public float timeSinceStroke = Mathf.Infinity;
  public bool advancedThisFrame = false;
  public float elapsedTripTime = 0;

  [Header("Initialization")]
  public Animator animator;

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
