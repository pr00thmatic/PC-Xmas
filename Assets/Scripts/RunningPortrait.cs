using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RunningPortrait : MonoBehaviour {
  [Header("Initialization")]
  public Animator animator;
  public Sprite[] fallStages;
  public new SpriteRenderer renderer;

  void Update () {
    animator.SetInteger("leg", Santa.Instance.leg);
  }

  public void UpdateSprite () {
    renderer.sprite = fallStages[Santa.Instance.currentFallLevel];
  }
}
