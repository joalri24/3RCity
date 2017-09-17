﻿using System.Collections.Generic;
using UnityEngine;

public class TrashTruckStation : MonoBehaviour {

    public const int TRUCK_CAPACITY = 3;

    [SerializeField]
    Transform trashTrucksSpawn;

    List<IDurabilityChangedListener> durabilityChangedListeners;
    List<TrashTruck> trashTrucks;

    int maxNumberOfTrucks = 5;
    int maxDurability = 50;

    TrashDeposit trashDeposit;
    int trashCollected = 0;
    int numberOfTrucks = 0;
    int durability;

	void Start () {
        TrashDeposit = GameObject.FindGameObjectWithTag("Controller").GetComponent<CityController>().defaultTrashDeposit;
        durability = maxDurability;
        durabilityChangedListeners = new List<IDurabilityChangedListener>(1);
        trashTrucks = new List<TrashTruck>(TRUCK_CAPACITY);
	}

    public TrashDeposit TrashDeposit
    {
        get { return trashDeposit; }
        set {
            trashDeposit = value;
            //EstadoJuego.InstanciaEstadoJuego.EnvironmentalImpact += trashDeposit.EnvironmentalImpact;
        }
    }

    public int MaxDurability
    {
        get { return maxDurability; }
    }

    public void AddTrashTruck(TrashTruck truck)
    {
        truck.AssignedTrashDeposit = trashDeposit;
        trashTrucks.Add(truck);
    }

    public Vector3 TrashTruckSpawn
    {
        get { return trashTrucksSpawn.position; }
    }
}
