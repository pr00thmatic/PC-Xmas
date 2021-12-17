using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgressDependantPosition : MonoBehaviour {
  [Header("Configuration")]
  public float despawnDistance = 20;

  [Header("Information")]
  public float progressWhenSpawned = -100;
  public Vector3 originalPosition;

  [Header("Initialization")]
  public Transform nextThing;

  void OnEnable () {
    Initialize(transform.position);
  }

  public void Initialize (Vector3 originalPosition) {
    transform.position = this.originalPosition = originalPosition;
    progressWhenSpawned = Santa.Progress;
  }

  void Update () {
    if (nextThing.position.z < -despawnDistance) {
      Destroy(gameObject);
      return;
    }

    Vector3 p = originalPosition + (Santa.Progress - progressWhenSpawned) * -Vector3.forward;
    transform.position = Utils.SetZ(transform.position, p.z);
  }
}
