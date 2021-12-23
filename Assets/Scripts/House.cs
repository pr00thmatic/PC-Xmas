using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {
  [Header("Configuration")]
  public float goodProbability = 0.6f;
  public float density = 0.25f;

  [Header("Information")]
  public bool receivedGift = false;
  public bool IsGood { get => good.activeSelf; }
  public bool RequiresGift { get => model.activeSelf && (good.activeSelf || evil.activeSelf); }

  [Header("Initialization")]
  public GameObject evil;
  public GameObject good;
  public Transform giftTarget;
  public GameObject model;
  public GameObject inRangeIndicator;

  void OnEnable () {
    inRangeIndicator.SetActive(false);
    good.SetActive(false); evil.SetActive(false);
    if (Random.Range(0,1f) <= density) {
      good.SetActive(Random.Range(0, 1f) <= goodProbability);
      evil.SetActive(!IsGood);
    }
  }

  public void GetGift (SendableThing thing) {
    evil.SetActive(false);
    good.SetActive(false);
  }

  public void RegretSpawn () {
    model.SetActive(false);
  }
}
