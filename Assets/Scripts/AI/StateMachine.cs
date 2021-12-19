using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
  public event System.Action<State> onStateChange;

  void OnEnable () {
    foreach (Transform child in transform) {
      State childState = child.GetComponent<State>();
      if (childState) {
        childState.onExit += HandleStateChange;
      }
    }
  }

  public T GetState<T> () where T: MonoBehaviour {
    foreach (Transform child in transform) {
      T childState = child.GetComponent<T>();
      if (childState) {
        return childState;
      }
    }
    return null;
  }

  public T SetState<T> () where T: MonoBehaviour {
    foreach (Transform child in transform) {
      T childState = child.GetComponent<T>();
      if (childState) {
        if (!childState.gameObject.activeInHierarchy) {
          childState.gameObject.SetActive(true);
        }
        gameObject.SetActive(true);
        return childState;
      }
    }
    return null;
  }

  public State SetState (State state) {
    foreach (Transform child in transform) {
      if (child.GetComponent<State>() == state) {
        child.gameObject.SetActive(true);
        return child.GetComponent<State>();
      }
    }

    return null;
  }

  public bool IsActive<T> () where T: MonoBehaviour {
    foreach (Transform child in transform) {
      if (child.GetComponent<T>()) {
        if (child.gameObject.activeSelf) return true;
        return false;
      }
    }

    return false;
  }

  public GameObject SetState (int index) {
    GameObject found = transform.GetChild(index).gameObject;
    found.SetActive(true);
    return found;
  }

  public void HandleStateChange (State state) {
    if (gameObject.activeInHierarchy) {
      onStateChange?.Invoke(state);
    }
  }

  public State GetCurrentState () {
    foreach (Transform child in transform) {
      State state = child.GetComponent<State>();
      if (state.gameObject.activeSelf) return state;
    }
    return null;
  }
}
