using System;
using UnityEngine;

public class CityInitializer : MonoBehaviour {

    public int startingMoney;
    public int startingTrashInStreets;
    public int maxTrashInStreets;

    void Start() {
        CityController.Current.CurrentMoney = startingMoney;
        CityController.Current.MaxTrashInStreets = maxTrashInStreets;
        CityController.Current.TrashInStreets = startingTrashInStreets;
    }
}
