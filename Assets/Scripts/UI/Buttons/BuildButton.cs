using System;
using UnityEngine;
using UnityEngine.UI;


public class BuildButton : MonoBehaviour {//, IMoneyChangedListener {

    public Buildings.Type building;

    //Building buildingAttributes;
    Button buttonComponent;
    
    void Start()
    {
        buttonComponent = GetComponent<Button>();
        GameObject obj = Managers.Instance.PrefabManager.MapBuildingToPrefab(building);
        //buildingAttributes = obj.GetComponent<Building>();
        //EstadoJuego.InstanciaEstadoJuego.addOnMoneyChangedListener(this);
        //((IMoneyChangedListener) this).onMoneyChanged(); //initialize interactable
    }

    public void OnClick()
    {
        //UIStateController.Instance.CurrentState = UI.State.Construction;
        Managers.Instance.BuildingPlacement.PreviewBuilding(building);
    }

    //void IMoneyChangedListener.onMoneyChanged()
    //{
    //    if (EstadoJuego.InstanciaEstadoJuego.CantidadDinero >= buildingAttributes.Cost)
    //    {
    //        buttonComponent.interactable = true;
    //    }
    //    else
    //    {
    //        buttonComponent.interactable = false;
    //    }
    //}
}
