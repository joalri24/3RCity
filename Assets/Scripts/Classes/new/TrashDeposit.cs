using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDeposit : MonoBehaviour
{
    // --------------------------------------------------------
    // Attributes and properties
    // --------------------------------------------------------

    [SerializeField]
    private Transform truckStop;

    //[SerializeField]
    //private int environmentalImpact;

    [SerializeField]
    private TrashDeposits.Type type;

    int trashDeposited = 0;

    public Garbage Garbage { get; set; }

    public Transform TruckStop
    {
        get { return truckStop; }
    }

    public int TrashDeposited
    {
        get { return trashDeposited; }
        set { trashDeposited = value; }
    }

    public TrashDeposits.Type Type
    {
        get { return type; }
    }

    // --------------------------------------------------------
    // Methods
    // --------------------------------------------------------

    private void Start()
    {
        Garbage = new Garbage();
    }

    /// <summary>
    /// Do something with the current Garbage.
    /// </summary>
    public virtual void TreatGarbage()
    {
        // Do nothing here. Each class that inherits from this should implement its own garbage treatment 
    }

    /// <summary>
    /// Receives new garbage and adds it to the existent one.
    /// </summary>
    /// <param name="newGarbage"></param>
    public virtual void ReceiveGarbage(Garbage newGarbage)
    {
        TrashDeposited += newGarbage.Total;
        Garbage.AddGarbage(newGarbage);
    }
}
