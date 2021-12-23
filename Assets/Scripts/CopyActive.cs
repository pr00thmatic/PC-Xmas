using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CopyActive : MonoBehaviour {
  [Header("Initialization")]
  public GameObject copyFrom;
  public GameObject copyTo;

  void Update () {
    copyTo.SetActive(copyFrom.activeSelf);
  }
}
