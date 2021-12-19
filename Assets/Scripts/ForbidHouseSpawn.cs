using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForbidHouseSpawn : MonoBehaviour {
  void OnTriggerEnter (Collider c) {
    House house = c.GetComponentInParent<House>();
    if (!house) return;
    house.RegretSpawn();
  }
}
