using UnityEngine;
using System.Collections;

public class Util {
    public static T FindComponent<T> (Transform t) where T: Behaviour{
        T component;
        foreach (Transform child in t) {
            component = child.GetComponent<T>();
            if (component != null) {
                return component;
            } else {
                return FindComponent<T>(child);
            }
        }

        return null;
    }
}
