using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campaign : MonoBehaviour
{

    // --------------------------------------------------------
    // Constants
    // --------------------------------------------------------

    /// <summary>
    /// The campaign types.
    /// </summary>
    public enum CampaignType
    {
        Paper,
        Glass,
        Metal
    }


    // --------------------------------------------------------
    // Attributes
    // --------------------------------------------------------

    /// <summary>
    /// This campaign's type.
    /// </summary>
    public CampaignType camapaignType;

    /// <summary>
    /// The monetary cost of this campaing
    /// </summary>
    [Range(0,1000)]
    [Tooltip("The monetary cost of this campaing.")]
    public int cost;

    /// <summary>
    /// Name that's going to be displayed on the UI.
    /// </summary>
    [Tooltip("Name that's going to be displayed on the UI.")]
    public string campaignName;

    /// <summary>
    /// Short text that's going to be displayed on the UI.
    /// </summary>
    [Tooltip("Short description that's going to be displayed on the UI.")]
    public string description;

    // TODO: Remove! this was for debbuging only!
    public void Update()
    {
        // Pause the game when the key is pressed.
        if (Input.GetKeyDown("a"))
        {
            CityController c = GameObject.FindGameObjectWithTag("Controller").GetComponent<CityController>();
            c.ApplyCampaign(this);
        }
    }


}
