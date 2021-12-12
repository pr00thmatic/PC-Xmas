using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnableInProgress : MonoBehaviour {
  [Header("Configuration")]
  public float despawnDistance = 20;

  [Header("Information")]
  public float progressWhenSpawned = -100;
  public Santa santa;
  public Vector3 originalPosition;

  [Header("Initialization")]
  public Transform nextThing;

  void Update () {
    if (nextThing.position.z < -despawnDistance) {
      Destroy(gameObject);
      return;
    }

    transform.position = originalPosition + (santa.Progress - progressWhenSpawned) * -Vector3.forward;
  }

  public void Initialize (ProgressDependantSpawner spawner) {
    Utils.CopyTransform(transform, spawner.lastSpawned? spawner.lastSpawned.nextThing: spawner.firstSpawnable);

    transform.parent = spawner.folder;
    despawnDistance = spawner.despawnDistance;
    santa = spawner.santa;
    progressWhenSpawned = spawner.santa.Progress;
    originalPosition = transform.position;
  }
}
