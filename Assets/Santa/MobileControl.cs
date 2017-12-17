using UnityEngine;
using System.Collections;

public class MobileControl : MonoBehaviour {
    public float maxDistance = 1;

    public float currentRightDistance = 0;
    public float currentLeftDistance = 0;

    public Side lastUsedFoot = Side.right;

    void Update () {
        foreach (Touch touch in Input.touches) {
            Debug.Log(touch.deltaPosition.magnitude);
        }
    }
}
