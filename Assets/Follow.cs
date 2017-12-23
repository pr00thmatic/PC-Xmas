using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
    public GameObject target;
    
    void Update () {
        transform.position = target.transform.position;
    }
}
