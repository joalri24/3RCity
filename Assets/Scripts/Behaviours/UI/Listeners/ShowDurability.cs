using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowDurability : MonoBehaviour, IDurabilityChangedListener {

    TrashTruckStation station;
    public Text durabilityText;

    void Start()
    {
        station = GetComponent<TrashTruckStation>();
    }

    public void onDurabilityChanged()
    {
        //if (durabilityText.text != null)
        //{
        //    durabilityText.text = station.Durability + "/" + station.MaxDurability;
        //}
    }
}
