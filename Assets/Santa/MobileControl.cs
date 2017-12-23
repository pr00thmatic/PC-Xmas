using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LegFingersProfiler))]
public class MobileControl : MonoBehaviour {
    public bool isProfiling;

    public LegFingersProfiler profile;

    public FootAction left;
    public FootAction right;
    public FootAction current;

    public float smoothTreshold = 0.3f;
    public float speed = 5;

    private Animator _animator;
    private bool _switchedFootOnFrame = false;
    private Vector3 _beginning;

    void Start () {
        if (profile == null) {
            profile = GetComponent<LegFingersProfiler>();
        }

        left = new FootAction(profile.left);
        right = new FootAction(profile.right);
        current = left;

        _animator = Util.FindComponent<Animator>(transform);
    }

    void Update () {
        if (!isProfiling) {
            _switchedFootOnFrame = false;
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    _switchedFootOnFrame = true;
                    SwitchFoot();
                    current.BeginAction(touch);
                    _beginning = transform.position;
                } else if (touch.phase == TouchPhase.Moved) {
                    current.ContinueAction(touch);

                    Vector3 direction =
                        new Vector3(touch.deltaPosition.x, 0,
                                    touch.deltaPosition.y).normalized;
                    transform.forward = direction;

                    transform.position -= _beginning +
                        direction * current.value * speed;
                }
            }

            UpdateAnimator();
        }

        if (profile.enabled && !isProfiling) {
            profile.enabled = false;
        } else if (!profile.enabled && isProfiling) {
            profile.enabled = true;
        }
    }

    public void SwitchFoot () {
        current = current == left? right: left;
    }

    public void UpdateAnimator () {
        _animator.SetBool("left foot down", current == left);
        _animator.SetBool("right foot down", current == right);
        
        float value = current.value;
        if (!_switchedFootOnFrame) {
            float lastValue = _animator.GetFloat("foot value");
            if (Mathf.Abs(lastValue - value) > smoothTreshold) {
                value = value + smoothTreshold * Mathf.Sign(lastValue - value);
            }
        } else {
            value = 0;
        }
        _animator.SetFloat("foot value", value);
        _animator.SetFloat("speed", 0.8f);
    }
}
