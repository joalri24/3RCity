using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWhenMouseIn : MonoBehaviour {
	
    void Start()
    {
        if (!Screen.fullScreen)
        {
            enabled = false; //don't call Update() if we're not in fullscreen, as the script won't work
        }
    }

	void Update () {
        
	}
}
