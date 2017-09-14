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

    void DepositTrash()
    {
        trashTruck.AssignedTrashDeposit.TrashDeposited += trashTruck.CollectedTrash;
        trashTruck.CollectedTrash = 0;
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

    void CollectTrash()
    {
        //int collectableTrash = Mathf.Min(trashTruck.TrashCollectTarget.AccumulatedTrash, trashTruck.TrashCapacity - trashTruck.CollectedTrash);
        //trashTruck.CollectedTrash += collectableTrash;
        //trashTruck.TrashCollectTarget.AccumulatedTrash -= collectableTrash;
    }

    bool HasArrivedToDestination()
    {
        return navMeshAgent.hasPath && navMeshAgent.remainingDistance < 1f;
    }
}
