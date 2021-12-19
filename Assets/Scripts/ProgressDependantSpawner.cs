using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgressDependantSpawner : MonoBehaviour {
  [Header("Configuration")]
  public float spawnMinDistance = 200;
  public float despawnDistance = 20;

  [Header("Information")]
  public SpawnableInProgress lastSpawned;

  [Header("Initialization")]
  public SpawnableInProgress[] toSpawn;
  public Transform firstSpawnable;
  public Transform folder;
  public Santa santa;

  void Update () {
    if (!lastSpawned || lastSpawned.nextThing.position.z < spawnMinDistance) {
      SpawnNextThing();
    }
  }

  public void SpawnNextThing () {
    SpawnableInProgress spawned = Instantiate(Utils.RandomPick(toSpawn));
    spawned.Initialize(this);
    lastSpawned = spawned;
  }
}
