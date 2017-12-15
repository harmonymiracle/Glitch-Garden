using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour {

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    private static float difficulty = 1f;

    public static float Difficulty {
        get { return difficulty; }
        set {
            if (value >= 1 && value <= 3f) {
                difficulty = value;
            }
        }


    }


}
