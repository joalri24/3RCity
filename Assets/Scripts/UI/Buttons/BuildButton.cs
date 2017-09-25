using System;
using UnityEngine;
using UnityEngine.UI;


public class BuildButton : MonoBehaviour, IMoneyChangedListener {

    public Buildings.Type building;

    Buildable buildingAttributes;
    Button buttonComponent;
    
    void Start()
    {
        buttonComponent = GetComponent<Button>();
        GameObject buildingPrefab = Managers.PrefabManager.MapBuildingToPrefab(building);
        buildingAttributes = buildingPrefab.GetComponent<Buildable>();
        CityController.Current.RegisterMoneyChangedListener(this);
        ((IMoneyChangedListener) this).onMoneyChanged(); //initialize interactable
    }

    public void OnClick()
    {
        //UIStateController.Instance.CurrentState = UI.State.Construction;
        Managers.BuildingPlacementManager.PreviewBuilding(building);
    }

    void IMoneyChangedListener.onMoneyChanged() {
        if (CityController.Current.CurrentMoney >= buildingAttributes.Cost) {
            buttonComponent.interactable = true;
        } else {
            buttonComponent.interactable = false;
        }
    }
}
