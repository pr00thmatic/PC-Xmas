using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnableInProgress : MonoBehaviour {
  [Header("Initialization")]
  public ProgressDependantPosition position;
  public Transform nextThing { get => position.nextThing; set => position.nextThing = value; }

  public void Initialize (ProgressDependantSpawner spawner) {
    Utils.CopyTransform(transform, spawner.lastSpawned? spawner.lastSpawned.nextThing: spawner.firstSpawnable);

    transform.parent = spawner.folder;
    position.Initialize(transform.position);
  }
}
