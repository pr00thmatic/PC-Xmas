using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Indicator : MonoBehaviour {
  [Header("Configuration")]
  public float lifespan;

  IEnumerator Start () {
    yield return new WaitForSeconds(lifespan);
    Destroy(gameObject);
  }

  public void Spawn (Transform origin) {
    Indicator instantiated = Instantiate(this);
    Utils.CopyTransform(instantiated.transform, origin);
  }
}
