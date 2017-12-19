using UnityEngine;
using System.Collections;

[System.Serializable]
public class FootActionProfile {
    public float averageDistance = 0;
    public float maxDistance = 0;

    private int _samples = 0;

    private Vector2 _beginning;

    public void AddSample (float distance) {
        maxDistance = Mathf.Max(distance, maxDistance);
        averageDistance = (averageDistance * _samples) / (_samples + 1) + distance / (_samples + 1);
        _samples++;
    }

    public void BeginAction (Touch touch) {
        _beginning = touch.position;
    }

    public void EndAction (Touch touch) {
        AddSample((_beginning - touch.position).magnitude);
    }
}
