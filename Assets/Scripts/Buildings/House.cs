using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for a single house. A house generates garbage over time.
/// </summary>
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

    // TODO: cans for recyclable garbage.

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

    public Transform trashCan;

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
        garbage.regular += amount;
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

    public Transform TrashCan
    {
        get { return trashCan; }
    }
}
