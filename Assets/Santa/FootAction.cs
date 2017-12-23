using UnityEngine;
using System.Collections;

[System.Serializable]
public class FootAction {
    public FootActionProfile profile;
    public float value;

    private Vector2 _beginning;

    public FootAction (FootActionProfile profile) {
        this.profile = profile;
    }

    public void BeginAction (Touch touch) {
        _beginning = touch.position;
    }

    public void ContinueAction (Touch touch) {
        value = (_beginning - touch.position).magnitude / (profile.averageDistance - 0.3f);
        value = value < -1? -1: value > 1? 1: value;
    }
}
