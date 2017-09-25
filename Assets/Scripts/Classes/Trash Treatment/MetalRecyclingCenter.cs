using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalRecyclingCenter : TrashTreatmentCenter {

    void Start() {
        trashDeposit = new TrashCan(Garbage.Type.Metal, maxCapacity);
    }

    public override void TreatGarbage() {
        //do something with this, sometime. It is not called automatically by the TrashTreatmentCenter.
        //you can call it every X amount of time, or override the ReceiveGarbage(int amountOfGarbage) method
        //to call this within it
    }

}

