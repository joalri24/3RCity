﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Structure that represent a load of garbage. 
/// This garbage can be found on the houses, on the trucks or in the landfill.
/// For the moment, this is not a monobehaviour.
/// </summary>
public class Garbage
{
    // -----------------------------------------------------------
    // Attributes
    // -----------------------------------------------------------
    
    /// <summary>
    /// Amount of ordinary garbage. This is the garbage that can't be recicled by any means.
    /// </summary>
    public int ordinary;

    /// <summary>
    /// Amount of paper and cardboard. Recyclable.
    /// </summary>
    public int paper;

    /// <summary>
    /// Amount of glass. Recyclable.
    /// </summary>
    public int glass;

    /// <summary>
    /// Amount of metal. Recyclable.
    /// </summary>
    public int metal;


    // -----------------------------------------------------------
    // Methods
    // -----------------------------------------------------------

    public Garbage() { }

    public Garbage(int nRegular, int nPaper, int nGlass, int nMetal)
    {
        ordinary = nRegular;
        paper = nPaper;
        glass = nGlass;
        metal = nMetal;
    }
    
}
