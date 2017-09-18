﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for a single house. A house generates garbage over time.
/// </summary>
///
[RequireComponent(typeof(Collider))]
public class House : MonoBehaviour
{
    // ------------------------------------------------------------
    // Attributes and properties
    // ------------------------------------------------------------

    /// <summary>
    /// The current garbage in the house. 
    /// </summary>
    public Garbage garbage;

    /// <summary>
    /// Ordinary trash can's maximum capacity. 
    /// All recyclable garbage that is not currently being recycled goes here.
    /// </summary>
    [Header("Trash cans capacity")]
    [Tooltip("Ordinary trash can's maximum capacity")]
    [Range(1,100)]
    public int ordinaryCanCapacity;

    /// <summary>
    /// Ordinary trash current garbage.
    /// </summary>
    private int trashCanCurrentGarbage;

    /// <summary>
    /// Property to access the current ammount of garbage in the ordinary trash can.
    /// All recyclable garbage that is not currently being recycled goes here.
    /// </summary>
    public int TrashCanCurrentAmount
    {
        get { return trashCanCurrentGarbage; }
        set
        {
            trashCanCurrentGarbage = value;
            // TODO: do something else if neccesary, like updating the model if 
            // the current amount if higher than the capacity, etc.
        }
    }

    /// <summary>
    /// Paper trash can's maximum capacity. 
    /// </summary>
    [Tooltip("Paper  can's maximum capacity")]
    [Range(1, 100)]
    public int paperCanCapacity;

    /// <summary>
    /// Paper can current garbage.
    /// </summary>
    private int paperCanCurrentGarbage;

    /// <summary>
    /// Property to access the current ammount of garbage in the paper trash can.
    /// Only recycled paper goes here.
    /// </summary>
    public int PaperCanCurrentAmount
    {
        get { return paperCanCurrentGarbage; }
        set
        {
            paperCanCurrentGarbage = value;
            // TODO: do something else if neccesary, like updating the model if 
            // the current amount if higher than the capacity, etc.
        }
    }

    /// <summary>
    /// Glass trash can's maximum capacity. 
    /// </summary>
    [Tooltip("Glass can's maximum capacity")]
    [Range(1, 100)]
    public int glassCanCapacity;

    /// <summary>
    /// Glass can current garbage.
    /// </summary>
    private int glassCanCurrentGarbage;

    /// <summary>
    /// Property to access the current ammount of garbage in the glass trash can.
    /// Only recycled glass goes here.
    /// </summary>
    public int GlassCanCurrentAmount
    {
        get { return glassCanCurrentGarbage; }
        set
        {
            glassCanCurrentGarbage = value;
            // TODO: do something else if neccesary, like updating the model if 
            // the current amount if higher than the capacity, etc.
        }
    }

    /// <summary>
    /// Metal trash can's maximum capacity. 
    /// </summary>
    [Tooltip("Metal can's maximum capacity")]
    [Range(1, 100)]
    public int metalCanCapacity;

    /// <summary>
    /// Metal can current garbage.
    /// </summary>
    private int metalCanCurrentGarbage;

    /// <summary>
    /// Property to access the current ammount of garbage in the metal trash can.
    /// Only recycled metal goes here.
    /// </summary>
    public int MetalCanCurrentAmount
    {
        get { return metalCanCurrentGarbage; }
        set
        {
            metalCanCurrentGarbage = value;
            // TODO: do something else if neccesary, like updating the model if 
            // the current amount if higher than the capacity, etc.
        }
    }

    /// <summary>
    /// The minimun of ordinary garbage that can be generated daily
    /// </summary>
    [Header("Garbage generation")]
    [Tooltip("The minimun of ordinary garbage that can be generated daily")]
    public int ordinaryMinimunGeneration;

    /// <summary>
    /// The maximun of ordinary garbage that can be generated daily
    /// </summary>
    [Tooltip("The maximun of ordinary garbage that can be generated daily")]
    public int ordinaryMaximunGeneration;

    /// <summary>
    /// The minimun of paper that can be generated daily
    /// </summary>
    [Tooltip("The minimun of paper that can be generated daily")]
    public int paperMinimunGeneration;

    /// <summary>
    /// The maximun of paper that can be generated daily
    /// </summary>
    [Tooltip("The maximum of paper garbage that can be generated daily")]
    public int paperMaximunGeneration;

    /// <summary>
    /// The minimun of paper that can be generated daily
    /// </summary>
    [Tooltip("The minimun of glass that can be generated daily")]
    public int glassMinimunGeneration;

    /// <summary>
    /// The maximun of paper that can be generated daily
    /// </summary>
    [Tooltip("The maximum of glass garbage that can be generated daily")]
    public int glassMaximunGeneration;

    /// <summary>
    /// The minimun of metal that can be generated daily
    /// </summary>
    [Tooltip("The minimun of metal that can be generated daily")]
    public int metalMinimunGeneration;

    /// <summary>
    /// The maximun of metal that can be generated daily
    /// </summary>
    [Tooltip("The maximum of metal garbage that can be generated daily")]
    public int metalMaximunGeneration;

    /// <summary>
    /// The transform of the place where the trucks stop to collect the garbage. 
    /// </summary>
    public Transform trashCanTrasnform;

    /// <summary>
    /// Position of the trash can
    /// </summary>
    public Transform TrashCan
    {
        get { return trashCanTrasnform; }
    }

    // ------------------------------------------------------------
    // Methods
    // ------------------------------------------------------------

    void Start ()
    {
        garbage = new Garbage(0, 0, 0, 0);
    }
	
    /// <summary>
    /// Generates new garbage and add it to the current amount.
    /// It puts each type of garbage in the proper can, but only if the house is recycling.
    /// </summary>
    public void GenerateGarbage()
    {
        int amount = 0;

        // Ordinary garbage
        amount = UnityEngine.Random.Range(ordinaryMinimunGeneration, ordinaryMaximunGeneration);
        garbage.ordinary += amount;
        TrashCanCurrentAmount += amount;

        // Paper  
        amount = UnityEngine.Random.Range(paperMinimunGeneration, paperMaximunGeneration);
        garbage.paper += amount;
        // TODO: if the house is recycling, put it in the paper can. If not, in the ordinary can.
        TrashCanCurrentAmount += amount;

        // glass 
        amount = UnityEngine.Random.Range(glassMinimunGeneration, glassMaximunGeneration);
        garbage.glass += amount;
        // TODO: if the house is recycling, put it in the glass can. If not, in the ordinary can.
        TrashCanCurrentAmount += amount;

        // metal 
        amount = UnityEngine.Random.Range(metalMinimunGeneration, metalMaximunGeneration);
        garbage.metal += amount;
        // TODO: if the house is recycling, put it in the metal can. If not, in the ordinary can.
        TrashCanCurrentAmount += amount;
    }

    /// <summary>
    /// Executed when the mouse enters the collider.
    /// </summary>
    private void OnMouseEnter()
    {
        /*Debug.Log("--------------------");
        Debug.Log("Ordinary can: " + TrashCanCurrentAmount+"/"+ordinaryCanCapacity);
        Debug.Log("Paper can: " + PaperCanCurrentAmount + "/" + paperCanCapacity);*/
    }

    private void OnMouseExit()
    {
        // TODO: hide the house info.
    }

}
