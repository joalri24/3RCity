using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDeposit : MonoBehaviour {

    [SerializeField]
    private Transform truckStop;

    [SerializeField]
    private int environmentalImpact;

    [SerializeField]
    private TrashDeposits.Type type;

    int trashDeposited = 0;

    public Transform TruckStop
    {
        get { return truckStop; }
    }

    public int TrashDeposited
    {
        get { return trashDeposited; }
        set { trashDeposited = value; }
    }

    public int EnvironmentalImpact
    {
        get { return environmentalImpact; }
    }

    public TrashDeposits.Type Type
    {
        get { return type; }
    }
}
