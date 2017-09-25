using System;
using System.Collections.Generic;
using UnityEngine;

public class TrashTruckStation : Buildable {

    public const int TRUCK_CAPACITY = 3;

    [SerializeField]
    Transform trashTrucksSpawn;

    [SerializeField]
    [Tooltip("Type of garbage the trucks of this station will collect")]
    private Garbage.Type collectedGarbageType;

    List<TrashTruck> trashTrucks;

    TrashTreatmentCenter currentTreatmentCenter;
    int trashCollected = 0;
    int numberOfTrucks = 0;

	void Start () {
        currentTreatmentCenter = GameObject.FindGameObjectWithTag("Controller").GetComponent<CityController>().defaultTrashTreatmentCenter;
        trashTrucks = new List<TrashTruck>(TRUCK_CAPACITY);
        buildingRenderer = transform.Find("Model").gameObject.GetComponent<Renderer>();
        originalColor = buildingRenderer.material.color;
    }

    public TrashTreatmentCenter CurrentTrashTreatmentCenter
    {
        get { return currentTreatmentCenter; }
        set {
            currentTreatmentCenter = value;
            //EstadoJuego.InstanciaEstadoJuego.EnvironmentalImpact += TrashTreatmentCenter.EnvironmentalImpact;
        }
    }

    public void AddTrashTruck(TrashTruck truck)
    {
        truck.AssignedTrashTreatmentCenter = currentTreatmentCenter;
        truck.CollectedGabargeType = collectedGarbageType;
        trashTrucks.Add(truck);
    }

    /// <summary>
    /// Colors the station green
    /// </summary>
    public override void ColorGreen() {
        buildingRenderer.material.color = Color.green;
    }

    /// <summary>
    /// Colors the station red
    /// </summary>
    public override void ColorRed() {
        buildingRenderer.material.color = Color.red;
    }

    /// <summary>
    /// Returns the station to its original color
    /// </summary>
    public override void ColorOriginal() {
        buildingRenderer.material.color = originalColor;
    }

    /// <summary>
    /// Is executed when the truck station gets actually placed in the world after previewing
    /// </summary>
    public override void Place() {
        ColorOriginal();
        transform.Find("Model").gameObject.layer = Buildings.Layer;
         
        if (collectedGarbageType == Garbage.Type.Ordinary) { //if it's an ordinary station
            BeginOperations(); //spawn trucks and stuff as soon as placed
        }
        //if it's a paper station, it'll probably be a treatment center too, so...
        else if (collectedGarbageType == Garbage.Type.Paper) { 
            //do something like only spawning trucks if there's a campaign active
        }
        else if (collectedGarbageType == Garbage.Type.Glass) {

        }
        else if(collectedGarbageType == Garbage.Type.Metal) {

        }
    }

    public void BeginOperations() {
        GetComponent<TrashTruckStationAI>().BeginOperations();
    }

    public Vector3 TrashTruckSpawn
    {
        get { return trashTrucksSpawn.position; }
    }
}
