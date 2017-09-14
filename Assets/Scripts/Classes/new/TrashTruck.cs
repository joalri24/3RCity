using UnityEngine;

public class TrashTruck : MonoBehaviour {

    int trashCapacity = 8;
    int collectedTrash = 0;
    House trashCollectTarget;
    TrashDeposit assignedTrashDeposit;

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
