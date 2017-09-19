using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines the behaviour of the UI panel that displays the Garbage of a selected building.
/// </summary>
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
public class DisplayGarbagePanel : MonoBehaviour
{
    // ---------------------------------------------------------
    // Attributes
    // ---------------------------------------------------------

    public RectTransform titlePanel;
    public RectTransform extraInfoPanel;
    public RectTransform ordinaryGarbagePanel;
    public RectTransform paperPanel;
    public RectTransform glassPanel;
    public RectTransform metalPanel;

    public Text ordinaryText;
    public Text paperText;
    public Text glassText;
    public Text metalText;

    /// <summary>
    /// Reference to this object's RectTransform
    /// </summary>
    private RectTransform rectTransform;

    /// <summary>
    /// The currently displayed house's maximun ordinary garbage capacity.
    /// </summary>
    private int ordinaryCapacity;

    /// <summary>
    /// The currently displayed house's maximun paper garbage capacity.
    /// </summary>
    private int paperCapacity;

    /// <summary>
    /// The currently displayed house's maximun glass garbage capacity.
    /// </summary>
    private int glassCapacity;

    /// <summary>
    /// The currently displayed house's maximun metal garbage capacity.
    /// </summary>
    private int metalCapacity;



    // ---------------------------------------------------------
    // Methods
    // ---------------------------------------------------------
    /// <summary>
    /// Displays the panel. It calculates and sets the Panel's Height based on the active child panels.
    /// </summary>
    /// <param name="displayOrdinary">Should display the ordinary garabge?</param>
    /// <param name="displayPaper">Should display the ordinary garabge?</param>
    /// <param name="displayMetal">Should display the ordinary garabge?</param>
    /// <param name="displayGlass">Should display the ordinary garabge?</param>
    /// <param name="ordinaryAmount"></param>
    /// <param name="paperAmount"></param>
    /// <param name="glassAmount"></param>
    /// <param name="metalAmount"></param>
    /// <param name="ordinaryCapacityP"></param>
    /// <param name="glassCapacityP"></param>
    /// <param name="paperCapacityP"></param>
    /// <param name="metalCapacityP"></param>
    public void DisplayPanel(bool displayOrdinary, bool displayPaper, bool displayMetal, bool displayGlass, int ordinaryAmount, int paperAmount, int glassAmount, int metalAmount, int ordinaryCapacityP, int glassCapacityP, int paperCapacityP, int metalCapacityP)
    {

        rectTransform = GetComponent<RectTransform>();

        ordinaryCapacity = ordinaryCapacityP;
        paperCapacity = paperCapacityP;
        glassCapacity = glassCapacityP;
        metalCapacity = metalCapacityP;

        ordinaryGarbagePanel.gameObject.SetActive(displayOrdinary);
        paperPanel.gameObject.SetActive(displayPaper);
        glassPanel.gameObject.SetActive(displayGlass);
        metalPanel.gameObject.SetActive(displayMetal);
        gameObject.SetActive(true);

        // Get the height that the panel should have.
        float panelHeight = 7f;
        panelHeight += (titlePanel.gameObject.activeInHierarchy) ? titlePanel.sizeDelta.y : 0;
        panelHeight += (extraInfoPanel.gameObject.activeInHierarchy) ? extraInfoPanel.sizeDelta.y : 0;
        panelHeight += (ordinaryGarbagePanel.gameObject.activeInHierarchy) ? ordinaryGarbagePanel.sizeDelta.y : 0;
        panelHeight += (paperPanel.gameObject.activeInHierarchy) ? paperPanel.sizeDelta.y : 0;
        panelHeight += (glassPanel.gameObject.activeInHierarchy) ? glassPanel.sizeDelta.y : 0;
        panelHeight += (metalPanel.gameObject.activeInHierarchy) ? metalPanel.sizeDelta.y : 0;

        rectTransform.sizeDelta = new Vector2(0f, panelHeight); // this line resizes the panel.
        UpdateValues(ordinaryAmount, paperAmount, glassAmount, metalAmount);
        
    }

    /// <summary>
    /// Updates the values of the displayed data.
    /// </summary>
    /// <param name="ordinaryAmount"></param>
    /// <param name="paperAmount"></param>
    /// <param name="glassAmount"></param>
    /// <param name="metalAmount"></param>
    public void UpdateValues (int ordinaryAmount, int paperAmount, int glassAmount, int metalAmount)
    {
        ordinaryText.text= ordinaryAmount.ToString() + "/" + ordinaryCapacity;
        paperText.text = paperAmount.ToString() + "/" + paperCapacity;
        glassText.text = glassAmount.ToString() + "/" + glassCapacity;
        metalText.text = metalAmount.ToString() + "/" + metalCapacity;
    }


}
