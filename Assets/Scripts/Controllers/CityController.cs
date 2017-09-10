using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Scene controllers.
/// It knows the city' status and what building currently exists on it.
/// It also makes the city's date advance.
/// </summary>
public class CityController : MonoBehaviour
{

    // -----------------------------------------------------------
    // Attributes and properties
    // -----------------------------------------------------------

    /// <summary>
    /// The duration in game days of the current match.
    /// </summary>
    [Header("Match settings")]
    [Tooltip("The duration in game days of the current match")]
    [Range (2,1500)]
    public int matchLength;

    /// <summary>
    /// The duration in real life seconds of a day in the game.
    /// </summary>
    [Tooltip("The duration in real life seconds of a day in the game")]
    [Range(0.5f, 200)]
    public float dayDuration;

    /// <summary>
    /// The current day on the game.
    /// </summary>
    private int currentDay;

    /// <summary>
    /// The start date on the game.
    /// </summary>
    private DateTime startDate;

    /// <summary>
    /// List with all the houses of the city.
    /// </summary>   
    [Header("City buildings")]
    [Tooltip("List with all the houses of the city")]
    public List<House> houses;

    // TODO: list of other buildings


    /// <summary>
    /// Timer to know when to advance to the next day.
    /// </summary>
    private float timer;

    /// <summary>
    /// Flag to know if the game is paused or not.
    /// </summary>
    private bool paused;

    /// <summary>
    /// Property used to pause and unpause the game.
    /// </summary>
    public bool Paused
    {
        get {return  paused; }
        set
        {
            paused = value;
            if (paused)
            {
                // TODO:
                Debug.Log("Paused");
            }
            else
            {
                Debug.Log("Unpaused");
            }
            
        }
    }

    // -----------------------------------------------------------
    // Methods
    // -----------------------------------------------------------

    /// <summary>
    /// Executed the first frame this object is alive.
    /// </summary>
    private void Start()
    {
        currentDay = 0;
        timer = 0f;
        startDate = DateTime.Now;
        Debug.Log("Current date: " + startDate.AddDays(currentDay).ToString("dd/MM/yyyy"));
    }

    /// <summary>
    /// Called to move forward a day on the time.
    /// </summary>
    private void AdvanceDay()
    {
        currentDay++;

        // Generate garbage in all houses
        foreach (var house in houses)
        {
            house.GenerateGarbage();
            Debug.Log("-----");
            Debug.Log("reg:" + house.garbage.regular);
            Debug.Log("pap:" + house.garbage.paper);
            Debug.Log("met:" + house.garbage.metal);
            Debug.Log("glass:" + house.garbage.glass);
            Debug.Log("tot:" + house.TrashCanCurrentAmount);
        }

        Debug.Log("Current date: " + startDate.AddDays(currentDay).ToString("dd/MM/yyyy"));

        if(currentDay >= matchLength)
        {
            // TODO: llamar al método de terminar partida
            Paused = true;
            Debug.Log("Time's up!");
        }
    }

	// Update is called once per frame
	void Update ()
    {
        // Pause the game when the key is pressed.
        if (Input.GetKeyDown("pause") || Input.GetKeyDown("p"))
            Paused = (Paused) ? false : true;
        
        // Add the passed time to the timer if the game is unpaused.
        if(!Paused)
            timer += Time.deltaTime;

        // Advance day when the proper amount of time has passed.
        if (timer >= dayDuration)
        {
            AdvanceDay();
            timer = 0;
        }
            
	}
}
