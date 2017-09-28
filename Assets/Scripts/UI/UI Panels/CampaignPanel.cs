using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampaignPanel : MonoBehaviour
{

    // ----------------------------------------------------------
    // Attributes and properties
    // ----------------------------------------------------------

    public Campaign campaign;

    public Text campaignTitle;
    public Text campaignCost;
    public Image campaignImage;
    public Sprite soldOutImage;

    private Button buyButton;


    // ----------------------------------------------------------
    // Methods
    // ----------------------------------------------------------

    private void Start()
    {
        buyButton = GetComponentInChildren<Button>();
        campaignTitle.text = campaign.campaignName;
        campaignImage.sprite = campaign.logo;
        campaignCost.text = "$" + campaign.cost;
    }

    public void BuyCampaign()
    {
        CityController.Current.ApplyCampaign(campaign);
        buyButton.enabled = false;
        campaignImage.sprite = soldOutImage;
        
    }

}
