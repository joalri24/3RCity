using UnityEngine;

public class TrashCan {

    Garbage.Type type;
    int capacity;
    int currentAmount;
    int amountInStreets;

    public Garbage.Type Type {
        get { return type; }
    }

    public int Capacity {
        get { return capacity; }
        set { capacity = value; }
    }

    public int CurrentAmount {
        get { return currentAmount; }
        set {
            currentAmount = value;
        }
    }

    public TrashCan(Garbage.Type type, int capacity) {
        this.type = type;
        this.capacity = capacity;
    }

    /// <summary>
    /// Withraws trash from the trash can. If there was trash in the streets when picking up,
    /// reduces trash in the streets
    /// </summary>
    /// <param name="pickupAmount"></param>
    public void PickupTrash(int pickupAmount) {
        if (amountInStreets > 0) {
            CityController.Current.TrashInStreets -= Mathf.Min(pickupAmount, amountInStreets);
            amountInStreets -= Mathf.Min(pickupAmount, amountInStreets);
        }
        currentAmount -= pickupAmount;
    }

    public void DepositTrash(int depositAmount) {
        if (currentAmount > capacity) {
            amountInStreets += depositAmount;
            CityController.Current.TrashInStreets += depositAmount;
        }
        else if (currentAmount + depositAmount > capacity) {
            amountInStreets += (currentAmount + depositAmount) - capacity;
            CityController.Current.TrashInStreets += amountInStreets;
        }
        currentAmount += depositAmount;
    }
}