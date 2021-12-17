using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Progress : NonPersistentSingleton<Progress> {
  [Header("Configuration")]
  public int totalCoal;
  public int totalGifts;
  public float requiredDistance;

  [Header("Information")]
  public int spentCoal = 0;
  public int spentGifts = 0;
  public int coalFails = 0;
  public int giftsFails = 0;

  [Header("Initialization")]
  public Image distance;
  public Image spirit;
  public Image coal;
  public Image gifts;

  void OnEnable () {
    SantaGiftGiver.onGiftSpent += HandleGift;
  }

  void OnDisable () {
    SantaGiftGiver.onGiftSpent -= HandleGift;
  }

  void Update () {
    distance.fillAmount = Santa.Progress / requiredDistance;
    coal.fillAmount = totalCoal == 0? 0: (1 - spentCoal / (float) totalCoal);
    gifts.fillAmount = totalGifts == 0? 0: (1 - spentGifts / (float) totalGifts);
  }

  public void HandleGift (bool isItAGift, bool wasWellSpent) {
    int g = isItAGift? 1: 0; int c = isItAGift? 0: 1;
    spentGifts += g; spentCoal += c;
    if (!wasWellSpent) { giftsFails += g; coalFails += c; }
  }
}
