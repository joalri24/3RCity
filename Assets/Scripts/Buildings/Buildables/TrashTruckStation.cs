using System;
using System.Collections.Generic;
using UnityEngine;

public class TrashTruckStation : Buildable {

    public const int TRUCK_CAPACITY = 3;

    [SerializeField]
    Transform trashTrucksSpawn;

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
        trashTrucks.Add(truck);
    }

    public override void ColorGreen() {
        buildingRenderer.material.color = Color.green;
    }

    public override void ColorRed() {
        buildingRenderer.material.color = Color.red;
    }

    public override void ColorOriginal() {
        buildingRenderer.material.color = originalColor;
    }

    public override void Place() {
        ColorOriginal();
        transform.Find("Model").gameObject.layer = Buildings.Layer;
        GetComponent<TrashTruckStationAI>().BeginOperations();
    }

    public Vector3 TrashTruckSpawn
    {
        get { return trashTrucksSpawn.position; }
    }
}
