using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for a single house. A house generates garbage over time.
/// </summary>
///
[RequireComponent(typeof(Collider))]
public class House : MonoBehaviour
{
    // ------------------------------------------------------------
    // Attributes and properties
    // ------------------------------------------------------------

    /// <summary>
    /// The current garbage in the house. 
    /// </summary>
    public Garbage garbage;

    /// <summary>
    /// Ordinary trash can's maximum capacity. 
    /// All recyclable garbage that is not currently being recycled goes here.
    /// </summary>
    [Header("Trash cans capacity")]
    [Tooltip("Ordinary trash can's maximum capacity")]
    [Range(1,100)]
    public int ordinaryCanCapacity;

    /// <summary>
    /// Ordinary trash current garbage.
    /// </summary>
    private int trashCanCurrentGarbage;

    /// <summary>
    /// Property to access the current ammount of garbage in the ordinary trash can.
    /// All recyclable garbage that is not currently being recycled goes here.
    /// </summary>
    public int TrashCanCurrentAmount
    {
        get { return trashCanCurrentGarbage; }
        set
        {
            trashCanCurrentGarbage = value;
            // TODO: do something else if neccesary, like updating the model if 
            // the current amount if higher than the capacity, etc.
        }
    }

    /// <summary>
    /// Paper trash can's maximum capacity. 
    /// </summary>
    [Tooltip("Paper  can's maximum capacity")]
    [Range(1, 100)]
    public int paperCanCapacity;

    /// <summary>
    /// Paper can current garbage.
    /// </summary>
    private int paperCanCurrentGarbage;

    /// <summary>
    /// Property to access the current ammount of garbage in the paper trash can.
    /// Only recycled paper goes here.
    /// </summary>
    public int PaperCanCurrentAmount
    {
        get { return paperCanCurrentGarbage; }
        set
        {
            paperCanCurrentGarbage = value;
            // TODO: do something else if neccesary, like updating the model if 
            // the current amount if higher than the capacity, etc.
        }
    }

    /// <summary>
    /// Glass trash can's maximum capacity. 
    /// </summary>
    [Tooltip("Glass can's maximum capacity")]
    [Range(1, 100)]
    public int glassCanCapacity;

    /// <summary>
    /// Glass can current garbage.
    /// </summary>
    private int glassCanCurrentGarbage;

    /// <summary>
    /// Property to access the current ammount of garbage in the glass trash can.
    /// Only recycled glass goes here.
    /// </summary>
    public int GlassCanCurrentAmount
    {
        get { return glassCanCurrentGarbage; }
        set
        {
            glassCanCurrentGarbage = value;
            // TODO: do something else if neccesary, like updating the model if 
            // the current amount if higher than the capacity, etc.
        }
    }

    /// <summary>
    /// Metal trash can's maximum capacity. 
    /// </summary>
    [Tooltip("Metal can's maximum capacity")]
    [Range(1, 100)]
    public int metalCanCapacity;

    /// <summary>
    /// Metal can current garbage.
    /// </summary>
    private int metalCanCurrentGarbage;

    /// <summary>
    /// Property to access the current ammount of garbage in the metal trash can.
    /// Only recycled metal goes here.
    /// </summary>
    public int MetalCanCurrentAmount
    {
        get { return metalCanCurrentGarbage; }
        set
        {
            metalCanCurrentGarbage = value;
            // TODO: do something else if neccesary, like updating the model if 
            // the current amount if higher than the capacity, etc.
        }
    }

    /// <summary>
    /// The minimun of ordinary garbage that can be generated daily
    /// </summary>
    [Header("Garbage generation")]
    [Tooltip("The minimun of ordinary garbage that can be generated daily")]
    public int ordinaryMinimunGeneration;

    /// <summary>
    /// The maximun of ordinary garbage that can be generated daily
    /// </summary>
    [Tooltip("The maximun of ordinary garbage that can be generated daily")]
    public int ordinaryMaximunGeneration;

    /// <summary>
    /// The minimun of paper that can be generated daily
    /// </summary>
    [Tooltip("The minimun of paper that can be generated daily")]
    public int paperMinimunGeneration;

    /// <summary>
    /// The maximun of paper that can be generated daily
    /// </summary>
    [Tooltip("The maximum of paper garbage that can be generated daily")]
    public int paperMaximunGeneration;

    /// <summary>
    /// The minimun of paper that can be generated daily
    /// </summary>
    [Tooltip("The minimun of glass that can be generated daily")]
    public int glassMinimunGeneration;

    /// <summary>
    /// The maximun of paper that can be generated daily
    /// </summary>
    [Tooltip("The maximum of glass garbage that can be generated daily")]
    public int glassMaximunGeneration;

    /// <summary>
    /// The minimun of metal that can be generated daily
    /// </summary>
    [Tooltip("The minimun of metal that can be generated daily")]
    public int metalMinimunGeneration;

    /// <summary>
    /// The maximun of metal that can be generated daily
    /// </summary>
    [Tooltip("The maximum of metal garbage that can be generated daily")]
    public int metalMaximunGeneration;

    /// <summary>
    /// The transform of the place where the trucks stop to collect the garbage. 
    /// </summary>
    public Transform trashCanTrasnform;

    /// <summary>
    /// Position of the trash can
    /// </summary>
    public Transform TrashCan
    {
        get { return trashCanTrasnform; }
    }

    /// <summary>
    /// Prefab of the garbage bag model thet is displayed when the House generates garbage.
    /// </summary>
	public GameObject ordinaryTrashBag;

    /// <summary>
    /// Reference to the ordinary can transform. Is used to know where to place the garbage bags.
    /// </summary>
	private Transform ordinaryCanTransform;

    /// <summary>
    /// True if the house is recycling paper
    /// </summary>
    private bool isRecyclingPaper; 
    /// <summary>
    /// True if the house is recycling paper
    /// </summary>
    public bool IsRecyclingPaper
    {
        get { return isRecyclingPaper; }
        set
        {
            isRecyclingPaper = value;
            PaperCanObject.SetActive(value);          
        }
    }

    /// <summary>
    /// True if the house is recycling metal
    /// </summary>
    private bool isRecyclingMetal;

    /// <summary>
    /// True if the house is recycling metal.
    /// </summary>
    public bool IsRecyclingMetal
    {
        get { return isRecyclingMetal; }
        set
        {
            isRecyclingMetal = value;
            MetalCanObject.SetActive(value);
        }
    }

    /// <summary>
    /// True if the house is recycling glass.
    /// </summary>
    private bool isRecyclingGlass;

    /// <summary>
    /// True if the house is recycling glass.
    /// </summary>
    public bool IsRecyclingGlass
    {
        get { return isRecyclingGlass; }
        set
        {
            isRecyclingGlass = value;
            GlassCanObject.SetActive(value);
        }
    }

    /// <summary>
    /// Reference to the controller of the scene.
    /// </summary>
    private CityController controller;

    /// <summary>
    /// Reference to the UI panel tha diplays info about the house.
    /// </summary>
    private DisplayGarbagePanel houseInfoDisplay;

    /// <summary>
    /// The Object with the Paper can model.
    /// </summary>
    private GameObject PaperCanObject;

    /// <summary>
    /// The Object with the Glass can model.
    /// </summary>
    private GameObject GlassCanObject;

    /// <summary>
    /// The Object with the Metal can model.
    /// </summary>
    private GameObject MetalCanObject;

    // ------------------------------------------------------------
    // Methods
    // ------------------------------------------------------------

    void Start ()
    {
        garbage = new Garbage(0, 0, 0, 0);
		ordinaryCanTransform = transform.GetChild (0); // 0 is the ordinary can
        PaperCanObject = transform.GetChild(1).gameObject; // 1 is the paper can
        MetalCanObject = transform.GetChild(2).gameObject; // 2 is the metal can
        GlassCanObject = transform.GetChild(3).gameObject; // 3 is the glass can
        IsRecyclingGlass = false;
        IsRecyclingMetal = false;
        IsRecyclingPaper = false;
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<CityController>();
        houseInfoDisplay = controller.houseInfoPanel;

    }
	
    /// <summary>
    /// Generates new garbage and add it to the current amount.
    /// It puts each type of garbage in the proper can, but only if the house is recycling.
    /// </summary>
    public void GenerateGarbage()
    {
        int amount = 0;

        // Ordinary garbage
        amount = UnityEngine.Random.Range(ordinaryMinimunGeneration, ordinaryMaximunGeneration);
        garbage.ordinary += amount;
        TrashCanCurrentAmount += amount;
		Vector3 bagPosition = ordinaryCanTransform.position;
		bagPosition.y += 1f;
		bagPosition.x += -0.166f; 
		bagPosition.z += -0.7481f;
		GameObject instance= Instantiate(ordinaryTrashBag, bagPosition, Quaternion.identity, this.transform );


        // Paper  
        amount = UnityEngine.Random.Range(paperMinimunGeneration, paperMaximunGeneration);
        garbage.paper += amount;
        if (IsRecyclingPaper)
        {
            PaperCanCurrentAmount += amount;
            // Instanciate paper bag
        }
            
        else
            TrashCanCurrentAmount += amount;

        // glass 
        amount = UnityEngine.Random.Range(glassMinimunGeneration, glassMaximunGeneration);
        garbage.glass += amount;
        if (IsRecyclingGlass)
        {
            GlassCanCurrentAmount += amount;
            // Instanciate paper bag
        }

        else
            TrashCanCurrentAmount += amount;

        // metal 
        amount = UnityEngine.Random.Range(metalMinimunGeneration, metalMaximunGeneration);
        garbage.metal += amount;
        if (IsRecyclingMetal)
        {
            MetalCanCurrentAmount += amount;
            // Instanciate paper bag
        }

        else
            TrashCanCurrentAmount += amount;
    }

    /// <summary>
    /// Executed when the mouse enters the collider.
    /// Activates the Panel that displays the house's data.
    /// </summary>
    private void OnMouseEnter()
    {
        houseInfoDisplay.DisplayPanel( FindExtraInfoMessage(),
            displayOrdinary: true, ordinaryAmount: TrashCanCurrentAmount, ordinaryCapacityP: ordinaryCanCapacity, 
            displayGlass: IsRecyclingGlass, glassAmount: glassCanCurrentGarbage, glassCapacityP: glassCanCapacity,
            displayMetal: IsRecyclingMetal, metalAmount: metalCanCurrentGarbage, metalCapacityP: metalCanCapacity,
            displayPaper: IsRecyclingPaper, paperAmount: paperCanCurrentGarbage, paperCapacityP: paperCanCapacity);      
    }

    /// <summary>
    /// Executed each frame the mouse is over the collider.
    /// Updates the info panel's data.
    /// </summary>
    private void OnMouseOver()
    {
        houseInfoDisplay.UpdateValues(
            ordinaryAmount: TrashCanCurrentAmount,
            glassAmount: glassCanCurrentGarbage,
            metalAmount: metalCanCurrentGarbage,
            paperAmount: paperCanCurrentGarbage);
    }

    /// <summary>
    /// Executed when the mouse leaves the collider.
    /// Hides the panel that displays the House's data.
    /// </summary>
    private void OnMouseExit()
    {
        houseInfoDisplay.gameObject.SetActive(false);
    }

    /// <summary>
    /// Returns the message that should be displayed on the House info panel.
    /// </summary>
    /// <returns></returns>
    private string FindExtraInfoMessage()
    {
        string message = "";
        int recyclingCansCounter = 0;
        List<string> garbageNames = new List<string>();

        if(IsRecyclingPaper)
        {
            recyclingCansCounter++;
            garbageNames.Add( "papel");
        }

        if (IsRecyclingMetal)
        {
            recyclingCansCounter++;
            garbageNames.Add("metal");
        }

        if (IsRecyclingGlass)
        {
            recyclingCansCounter++;
            garbageNames.Add("vidrio");
        }

        switch (recyclingCansCounter)
        {
            case 0:
                message = "Esta casa no recicla.";
                break;

            case 1:
                message = "Esta casa solo recicla " + garbageNames[0] + ".";
                break;

            case 2:
                message = "Esta casa recicla " + garbageNames[0] + " y " + garbageNames[1] + ".";
                break;

            case 3:
                message = "Esta casa recicla todo tipo de desechos.";
                break;

            default:
                break;
        }

        return message;
    }

   

}
