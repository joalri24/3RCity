using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Landfill : TrashDeposit
{
    // --------------------------------------------------------
    // Attributes
    // --------------------------------------------------------

    /// <summary>
    /// Maximun capacity of the landfill.
    /// </summary>
    [Tooltip("Maximun capacity of the landfill.")]
    public int capacity;

    /// <summary>
    /// Reference to the controller of the scene.
    /// </summary>
    private CityController controller;

    /// <summary>
    /// Reference to the UI panel tha diplays info about the landfill.
    /// </summary>
    private DisplayGarbagePanel infoDisplay;


    // --------------------------------------------------------
    // Methods
    // --------------------------------------------------------
    protected override void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<CityController>();
        infoDisplay = controller.landfillInfoPanel;
        base.Start();
    }

    public override void TreatGarbage()
    {
        // Do something if the landfill is full.
    }

    /// <summary>
    /// Executed when the mouse enters the collider.
    /// Activates the Panel that displays the house's data.
    /// </summary>
    private void OnMouseEnter()
    {
        infoDisplay.DisplayPanel(
            displayOrdinary: true, ordinaryAmount: Garbage.ordinary, ordinaryCapacityP: capacity,
            displayGlass: true, glassAmount: Garbage.glass, glassCapacityP: 0,
            displayMetal: true, metalAmount: Garbage.metal, metalCapacityP: 0,
            displayPaper: true, paperAmount: Garbage.paper, paperCapacityP: 0);
    }

    /// <summary>
    /// Executed each frame the mouse is over the collider.
    /// Updates the info panel's data.
    /// </summary>
    private void OnMouseOver()
    {
        infoDisplay.UpdateValues(
            ordinaryAmount: Garbage.ordinary,
            glassAmount: Garbage.glass,
            metalAmount: Garbage.metal,
            paperAmount: Garbage.paper);
    }

    /// <summary>
    /// Executed when the mouse leaves the collider.
    /// Hides the panel that displays the House's data.
    /// </summary>
    private void OnMouseExit()
    {
        infoDisplay.gameObject.SetActive(false);
    }




}
