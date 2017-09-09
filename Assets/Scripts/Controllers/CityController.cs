using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scene controllers.
/// It knows the city' status and what building currently exists on it.
/// It also makes the city's date advance.
/// </summary>
public class CityController : MonoBehaviour
{

    // -----------------------------------------------------------
    // Attributes
    // -----------------------------------------------------------

    /// <summary>
    /// Property to access a list with all the houses of the city.
    /// </summary>
    public List<House> houses;

    // -----------------------------------------------------------
    // Methods
    // -----------------------------------------------------------

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown("b"))
        {
            Debug.Log(houses.Count);
        }
	}
}
