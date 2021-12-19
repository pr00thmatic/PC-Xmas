using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackButton : MonoBehaviour {
  [Header("Initialization")]
  public GameObject mainCamera;
  public Animator animator;

  void Update () {
    animator.SetBool("is visible", !mainCamera.activeSelf);
  }

  public void Click () {
    if (mainCamera.activeSelf) return;
    mainCamera.SetActive(true);
  }
}
