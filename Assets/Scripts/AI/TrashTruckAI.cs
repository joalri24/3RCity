using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrashTruckAI : MonoBehaviour {

    enum State
    {
        GoingToCollect,
        GoingToDeposit
    }

    State currentState;
    NavMeshAgent navMeshAgent;
    TrashTruck trashTruck;
    GameObject destination;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        trashTruck = GetComponent<TrashTruck>();
        TransitionToCollectState();
    }

    void Update()
    {
        if (HasArrivedToDestination())
        {
            if (currentState == State.GoingToCollect)
            {
                CollectTrash();
                if (trashTruck.IsFull())
                {
                    TransitionToDepositState();
                }
                else
                {
                    TransitionToCollectState();
                }
            }
            else if (currentState == State.GoingToDeposit)
            {
                DepositTrash();
                TransitionToCollectState();
            }
        }
    }

    private void TransitionToCollectState()
    {
        trashTruck.TrashCollectTarget = CityController.Current.NextHouseToCollect(trashTruck.CollectedGabargeType);
        navMeshAgent.SetDestination(trashTruck.TrashCollectTarget.TrashCan.position);
        currentState = State.GoingToCollect;
    }

    private void TransitionToDepositState()
    {
        navMeshAgent.SetDestination(trashTruck.AssignedTrashTreatmentCenter.TruckStop.position);
        currentState = State.GoingToDeposit;
    }

    /// <summary>
    /// Collects as much as possible of the type of trash the truck is supposed to pick up from the house
    /// the truck is currently attending
    /// </summary>
    private void CollectTrash()
    {
        int availableCapacity = trashTruck.TrashCapacity - trashTruck.CollectedTrash;
        int amountToCollect = 0;
        House house = trashTruck.TrashCollectTarget;

        //if the truck collects ordinary trash
        if (trashTruck.CollectedGabargeType == Garbage.Type.Ordinary) { 
            //collect as much ordinary trash as possible
            amountToCollect = Mathf.Min(house.OrdinaryTrashCan.CurrentAmount, availableCapacity);
            CollectOrdinaryTrashFrom(house, amountToCollect);
        }
        //if the truck collects paper
        else if (trashTruck.CollectedGabargeType == Garbage.Type.Paper) {
            //collect as much paper as possible
            amountToCollect = Mathf.Min(house.PaperTrashCan.CurrentAmount, availableCapacity);
            CollectPaperFrom(house, amountToCollect);
        }
        //if the truck collects glass
        else if (trashTruck.CollectedGabargeType == Garbage.Type.Glass) {
            //collect as much glass as possible
            amountToCollect = Mathf.Min(house.GlassTrashCan.CurrentAmount, availableCapacity);
            CollectGlassFrom(house, amountToCollect);
        }
        else if (trashTruck.CollectedGabargeType == Garbage.Type.Metal) {
            amountToCollect = Mathf.Min(house.GlassTrashCan.CurrentAmount, availableCapacity);
            CollectMetalFrom(house, amountToCollect);
        }
        trashTruck.CollectedTrash += amountToCollect;
    }

    private void CollectOrdinaryTrashFrom(House house, int amountToCollect) {
        trashTruck.Garbage.ordinary += amountToCollect;
        house.OrdinaryTrashCan.PickupTrash(amountToCollect);
    }

    private void CollectPaperFrom(House house, int amountToCollect) {
        trashTruck.Garbage.paper += amountToCollect;
        house.PaperTrashCan.PickupTrash(amountToCollect);
    }

    private void CollectGlassFrom(House house, int amountToCollect) {
        trashTruck.Garbage.glass += amountToCollect;
        house.GlassTrashCan.PickupTrash(amountToCollect);
    }

    private void CollectMetalFrom(House house, int amountToCollect) {
        trashTruck.Garbage.metal += amountToCollect;
        house.MetalTrashCan.PickupTrash(amountToCollect);
    }

    private void DepositTrash()
    {
        trashTruck.AssignedTrashTreatmentCenter.ReceiveGarbage(trashTruck.CollectedTrash);
        trashTruck.CollectedTrash = 0;
        trashTruck.Garbage = new Garbage();
    }

    private bool HasArrivedToDestination()
    {
        return !navMeshAgent.pathPending && navMeshAgent.hasPath && navMeshAgent.remainingDistance < 1f;
    }
}
