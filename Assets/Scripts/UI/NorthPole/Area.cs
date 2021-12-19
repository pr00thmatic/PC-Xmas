using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Area : MonoBehaviour {
  [Header("Initialization")]
  public new GameObject camera;

  void OnMouseDown () {
    camera.SetActive(true);
  }
}
