using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTruckStationAI : MonoBehaviour {

    TrashTruckStation station;
    float loseDurabilityCooldown = 5f;
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
        GameObject currentTruck = null;
        for (int i = 0; i < TrashTruckStation.TRUCK_CAPACITY; i++)
        {
            currentTruck = Instantiate(Managers.Instance.PrefabManager.TrashTruckPrefab(), station.TrashTruckSpawn, Quaternion.identity);
            station.AddTrashTruck(currentTruck.GetComponent<TrashTruck>());
        }
    }
}
