using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SendableThing : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 5;
  public bool isCoal;

  [Header("Information")]
  public House target;

  [Header("Initialization")]
  public ProgressDependantPosition position;

  public void GoTo (House house) {
    // position.Initialize(transform.position);
    position.enabled = false;
    transform.parent = house.transform;
    target = house;
    target.GetGift(this);
    StartCoroutine(_GoTo(house));
  }

  IEnumerator _GoTo (House house) {
    while (Vector3.Distance(transform.position, target.giftTarget.position) >= 0.02f) {
      transform.position = Vector3.MoveTowards(transform.position, target.giftTarget.position, speed * Time.deltaTime);
      yield return null;
    }
    transform.position = target.giftTarget.position;
  }
}
