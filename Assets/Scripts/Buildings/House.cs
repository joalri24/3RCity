using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {
    public Garbage garbage;
    //Trash can's maximum capacity
    public int trashCanCapacity;
    //Trash can's actual garbage 
    public int trashCanGarbage;

	// Use this for initialization
	void Start () {
        garbage = new Garbage(0, 0, 0, 0);
        
    }
	
	// Update is called once per frame
	void Update () {

        trashCanGarbage = garbage.regular + garbage.paper + garbage.glass + garbage.metal;

    }

    public void garbageProduction()
    {
        System.Random rnd = new System.Random();
        garbage.regular += rnd.Next(1, 13);  // regular garbage: >= 1 and < 13
        garbage.paper += rnd.Next(1, 13);    // paper garbage: >= 1 and < 13
        garbage.glass += rnd.Next(1,13);      // glass garbage: >= 1 and < 13
        garbage.metal += rnd.Next(1, 13);      // metal garbage: >= 1 and < 13


    }
    
}
