using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomRotation : MonoBehaviour {
  void OnEnable () {
    transform.Rotate(Random.Range(0,5), Random.Range(0,360), Random.Range(0,5));
  }
}
