using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landfill : TrashDeposit
{
    // --------------------------------------------------------
    // Attributes
    // --------------------------------------------------------

    /// <summary>
    /// Maximun capacity of the landfill.
    /// </summary>
    [Tooltip("Maximun capacity of the landfill.")]
    public int capacity;


    // --------------------------------------------------------
    // Methods
    // --------------------------------------------------------
    public override void ReceiveGarbage(Garbage newGarbage)
    {
        Debug.Log("Landill: or: " + Garbage.ordinary + " p: " + Garbage.paper + " g: " + Garbage.glass + " m: " + Garbage.metal);
        base.ReceiveGarbage(newGarbage);
    }
    public override void TreatGarbage()
    {
        // Do something if the landfill is full.
    }


}
