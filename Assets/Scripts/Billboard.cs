using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour {
  [Header("Initialization")]
  public new Camera camera;

  void OnEnable () {
    if (!camera) camera = Camera.main;
  }

  void Update () {
    transform.forward = -camera.transform.forward;
  }
}
