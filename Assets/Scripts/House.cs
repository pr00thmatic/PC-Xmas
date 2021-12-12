using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {
  [Header("Configuration")]
  public float goodProbability = 0.6f;
  public float density = 0.25f;

  // [Header("Information")]
  public bool IsGood { get => good.activeSelf; }
  public bool RequiresGift { get => good.activeSelf || evil.activeSelf; }
  public bool receivedGift = false;

  [Header("Initialization")]
  public GameObject evil;
  public GameObject good;

  void OnEnable () {
    if (Random.Range(0,1f) <= density) {
      good.SetActive(Random.Range(0, 1f) <= goodProbability);
      evil.SetActive(!IsGood);
    }
  }
}
