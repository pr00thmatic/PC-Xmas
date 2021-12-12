using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SantaGiftGiver : MonoBehaviour {
  [Header("Information")]
  public List<House> good;
  public List<House> evil;

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
}
