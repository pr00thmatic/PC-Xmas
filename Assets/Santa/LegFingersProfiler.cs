using UnityEngine;
using System.Collections;

public class LegFingerProfiler : MonoBehaviour {
    public Side currentFoot = Side.right;

    private float _leftFingerDistance;
    private float _rightFingerDistance;

    private float _leftBeginning;
    private float _rightBeginning;

    void Update () {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                _SetupBeginning(touch);
            } else if (touch.phase == TouchPhase.Ended) {
                _SetupEnd(touch);
            }
        }
    }

    private void _SetupEnd (Touch touch) {
        currentFoot = currentFoot == Side.right? Side.left : Side.right;
    }

    private void _SetupBeginning (Touch touch) {
        if (currentFoot == Side.right) {
            _leftBeginning = touch.position;
        } else {
            _rightBeginning = touch.position;
        }
    }
}
