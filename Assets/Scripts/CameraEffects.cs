using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraEffects : MonoBehaviour {
  [Header("Initialization")]
  public Animator animator;

  void OnEnable () {
    Santa.Instance.onFall += HandleFall;
  }

  void OnDisable () {
    if (Santa.Instance) Santa.Instance.onFall -= HandleFall;
  }

  public void HandleFall () {
    animator.SetTrigger("shake");
  }
}
