using UnityEngine;
using System.Collections;

public class LegFingersProfiler : MonoBehaviour {
    public FootActionProfile left;
    public FootActionProfile right;
    public FootActionProfile current;

    void Start () {
        current = left;
    }

    void Update () {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                _SwitchFoot();
                current.BeginAction(touch);
            } else if (touch.phase == TouchPhase.Ended) {
                current.EndAction(touch);
            }
        }
    }

    private void _SwitchFoot () {
        current = current == left? right: left;
    }
}
