using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    [SerializeField]
    TrashDeposit defaultDeposit;

    int currentCollectingHouseIndex = 0;
    List<House> houses;

    static City instance;

    void Start()
    {
        instance = this;
        houses = new List<House>();
    }

    public TrashDeposit DefaultTrashDeposit
    {
        get { return defaultDeposit; }
    }

    public void AddHouse(House house)
    {
        houses.Add(house);
    }

    public static City Instance
    {
        get {
            return instance;
        }
    }

    public House NextHouseToCollect()
    {
        House answer = houses[currentCollectingHouseIndex];
        currentCollectingHouseIndex++;
        if (currentCollectingHouseIndex > houses.Count-1)
        {
            currentCollectingHouseIndex = 0;
        }
        return answer;
    }
}
