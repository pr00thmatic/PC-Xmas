using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SantaGiftGiver : MonoBehaviour {
  [Header("Information")]
  public List<House> good;
  public List<House> evil;

  [Header("Initialization")]
  public SendableThing coal;
  public SendableThing gift;
  public Transform leftHouses;
  public Transform rightHouses;
  public Indicator nopeIndicator;

  void Update () {
    if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Z) ||
        Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.C)) {
      Transform houses = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Z)? leftHouses: rightHouses;
      SendableThing thing = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)? gift: coal;
      if (!Send(thing, houses)) nopeIndicator.Spawn(transform);
    }
  }

  void OnTriggerEnter (Collider c) {
    House house = c.GetComponentInParent<House>();
    if (!house || !house.RequiresGift || house.receivedGift || good.Contains(house) || evil.Contains(house)) return;

    (house.IsGood? good: evil).Add(house);
  }

  void OnTriggerExit (Collider c) {
    House house = c.GetComponentInParent<House>();
    if (!house) return;
    good.Remove(house); evil.Remove(house);
  }

  public bool Send (SendableThing thing, Transform houses) {
    List<House> availableHouses = thing == gift? good: evil;

    for (int i=0; i<availableHouses.Count; i++) {
      if (availableHouses[i].GetComponentInParent<ProgressDependantSpawner>().transform == houses) {
        Send(thing, availableHouses[i]);
        availableHouses.RemoveAt(i);
        return true;
      }
    }

    return false;
  }

  public void Send (SendableThing thing, House house) {
    SendableThing sent = Instantiate(thing);
    Utils.CopyTransform(sent.transform, transform);
    sent.GoTo(house);
  }
}
