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

    void TransitionToCollectState()
    {
        trashTruck.TrashCollectTarget = City.Instance.NextHouseToCollect();
        navMeshAgent.SetDestination(trashTruck.TrashCollectTarget.TrashCan.position);
        currentState = State.GoingToCollect;
    }

    void TransitionToDepositState()
    {
        navMeshAgent.SetDestination(trashTruck.AssignedTrashDeposit.TruckStop.position);
        currentState = State.GoingToDeposit;
    }

    /// <summary>
    /// Collects all the possible garbage from a House and puts it on the truck.
    /// This method assumes (for the moment) that the truck is and ordinary garbage truck.
    /// </summary>
    void CollectTrash()
    {
        int availableCapacity = trashTruck.TrashCapacity - trashTruck.CollectedTrash;
        int amountToCollect;
        House house = trashTruck.TrashCollectTarget;

        // ---------- Collect Ordinary garbage --------------------------
        amountToCollect = Mathf.Min(house.garbage.ordinary, availableCapacity); // The minimun between the available space and the house's curent ordinary garbage.
        trashTruck.CollectedTrash += amountToCollect; // Increase the truck's total garbage counter
        trashTruck.Garbage.ordinary += amountToCollect; // Put the garbage in the truck.
        house.garbage.ordinary -= amountToCollect; // Removes the garbage from the house.
        house.TrashCanCurrentAmount -= amountToCollect; // Decrease the House's ordinary trash counter
        // ---------------------------------------------------------------

        availableCapacity = trashTruck.TrashCapacity - trashTruck.CollectedTrash;    
        if (availableCapacity <= 0)
            return; // Stop collecting if there's no capacity available.

        // ---------- Collect wasted Paper --------------------------+
        int wastedPaper = house.garbage.paper - house.PaperCanCurrentAmount; // All paper that is not on the Paper Can is being wasted.
        amountToCollect = Mathf.Min(wastedPaper, availableCapacity); // The minimun between the available space and the house's curent wasted paper.
        trashTruck.CollectedTrash += amountToCollect; // Increase the truck's total garbage counter
        trashTruck.Garbage.paper += amountToCollect; // Put the garbage in the truck.
        house.garbage.paper -= amountToCollect; // Removes the garbage from the house.
        house.TrashCanCurrentAmount -= amountToCollect; // Decrease the House's ordinary trash counter
        // ---------------------------------------------------------------

        availableCapacity = trashTruck.TrashCapacity - trashTruck.CollectedTrash;    
        if (availableCapacity <= 0)
            return; // Stop collecting if there's no capacity available.

        // ---------- Collect wasted Glass --------------------------+
        int wastedGlass = house.garbage.glass - house.GlassCanCurrentAmount; // All glass that is not on the Glass Can is being wasted.
        amountToCollect = Mathf.Min(wastedGlass, availableCapacity); // The minimun between the available space and the house's curent wasted paper.
        trashTruck.CollectedTrash += amountToCollect; // Increase the truck's total garbage counter
        trashTruck.Garbage.glass += amountToCollect; // Put the garbage in the truck.
        house.garbage.glass -= amountToCollect; // Removes the garbage from the house.
        house.TrashCanCurrentAmount -= amountToCollect; // Decrease the House's ordinary trash counter
        // ---------------------------------------------------------------

        availableCapacity = trashTruck.TrashCapacity - trashTruck.CollectedTrash;
        if (availableCapacity <= 0)
            return; // Stop collecting if there's no capacity available.

        // ---------- Collect wasted Metal --------------------------+
        int wastedMetal = house.garbage.metal - house.MetalCanCurrentAmount; // All metal that is not on the Paper Can is being wasted.
        amountToCollect = Mathf.Min(wastedMetal, availableCapacity); // The minimun between the available space and the house's curent wasted paper.
        trashTruck.CollectedTrash += amountToCollect; // Increase the truck's total garbage counter
        trashTruck.Garbage.metal += amountToCollect; // Put the garbage in the truck.
        house.garbage.metal -= amountToCollect; // Removes the garbage from the house.
        house.TrashCanCurrentAmount -= amountToCollect; // Decrease the House's ordinary trash counter
        // ---------------------------------------------------------------
    }

    void DepositTrash()
    {
        trashTruck.AssignedTrashDeposit.TrashDeposited += trashTruck.CollectedTrash;
        trashTruck.CollectedTrash = 0;
    }

    bool HasArrivedToDestination()
    {
        return navMeshAgent.hasPath && navMeshAgent.remainingDistance < 1f;
    }
}
