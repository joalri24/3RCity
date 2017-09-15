﻿using UnityEngine;

public class TrashTruck : MonoBehaviour
{

    int trashCapacity = 8;

    /// <summary>
    /// Total amount of trash currently in the truck.
    /// </summary>
    int collectedTrash = 0;

    House trashCollectTarget;
    TrashDeposit assignedTrashDeposit;

    /// <summary>
    /// The current garbage. used to know the amount of each type of thrash.
    /// </summary>
    public Garbage Garbage { get; set; }

    /// <summary>
    /// Property to access the current amount of trash in the truck.
    /// </summary>
    public int CollectedTrash
    {
        get { return collectedTrash; }
        set {
            collectedTrash = value;
        }
    }

    public House TrashCollectTarget
    {
        get { return trashCollectTarget;  }
        set { trashCollectTarget = value; }
    }

    public TrashDeposit AssignedTrashDeposit
    {
        get { return assignedTrashDeposit; }
        set { assignedTrashDeposit = value; }
    }

    public int TrashCapacity
    {
        get { return trashCapacity; }
    }

    public bool IsFull()
    {
        return collectedTrash == trashCapacity;
    }
}
