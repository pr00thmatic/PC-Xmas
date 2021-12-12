using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SmoothFloat {
  public float current;
  public float target;
  public float smoothTime;
  public float velocity;

  public void Update () {
    current = Mathf.SmoothDamp(current, target, ref velocity, smoothTime);
  }
}
