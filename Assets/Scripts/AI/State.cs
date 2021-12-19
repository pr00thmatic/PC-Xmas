using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {
  public event System.Action<State> onExit;

  void OnEnable () {
    foreach (Transform brother in transform.parent) {
      if (brother.GetComponent<State>() && brother.gameObject.activeSelf && brother != transform) {
        brother.gameObject.SetActive(false);
      }
    }
  }

  void OnDisable () {
    onExit?.Invoke(this);
  }

  public void Next () {
    transform.parent.GetChild(transform.GetSiblingIndex()+1).gameObject.SetActive(true);
  }
}
