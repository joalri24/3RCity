using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour {

    public int regular;
    public int paper;
    public int glass;
    public int metal;

	// Use this for initialization
	void Start () {
        //regular = 0;
        //paper = 0;
        //glass = 0;
        //metal = 0;
		
	}

    // Update is called once per frame
    void Update()
    {

    }
    public Garbage(int nRegular, int nPaper, int nGlass, int nMetal)
    {
        regular = nRegular;
        paper = nPaper;
        glass = nGlass;
        metal = nMetal;
    }
    
}
