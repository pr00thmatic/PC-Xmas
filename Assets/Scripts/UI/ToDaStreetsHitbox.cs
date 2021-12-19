using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ToDaStreetsHitbox : MonoBehaviour {
  void OnMouseDown () {
    if (EventSystem.current.IsPointerOverGameObject()) return;
    SceneManager.LoadScene("DaStreets");
  }
}
