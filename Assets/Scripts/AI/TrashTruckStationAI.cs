using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTruckStationAI : MonoBehaviour {

    TrashTruckStation station;
    float timeSinceDurabilityLost = 0f;

    void Start()
    {
        enabled = false;
        station = GetComponent<TrashTruckStation>();
    }

    public void BeginOperations()
    {
        PlaceTrucks();
        enabled = true;
    }

    void PlaceTrucks()
    {
        GameObject currentTruck = Managers.PrefabManager.TrashTruckPrefabOfType(station.CollectedGarbageType);
        for (int i = 0; i < TrashTruckStation.TRUCK_CAPACITY; i++)
        {
            currentTruck = Instantiate(currentTruck, station.TrashTruckSpawn, Quaternion.identity);
            station.AddTrashTruck(currentTruck.GetComponent<TrashTruck>());
        }
    }
}
