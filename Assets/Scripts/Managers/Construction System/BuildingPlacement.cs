using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {

    BuildingPreview buildingPreview;

    void Start()
    {
        buildingPreview = GetComponent<BuildingPreview>();
    }

    public void Place(Buildable buildable) {
        buildable.Place();
        CityController.Current.CurrentMoney -= buildable.Cost;
    }

	public void PreviewBuilding(Buildings.Type buildingType)
    {
        if (UIController.Current.State == UI.State.BuildingPreview) {
            buildingPreview.CancelPreview();
        }
        UIController.Current.State = UI.State.BuildingPreview;
        buildingPreview.StartBuildingPreview(buildingType);
    }

    public bool CanBuildingBePlacedInTile(Buildings.Type buildingType, string tileTag)
    {
        return TilesBuildingCanBePlaced(buildingType).Contains(tileTag);
    }

    /// <summary>
    /// Returns array of the tags of tiles where a building of buildingType can be placed.
    /// Exists so logic regarding building placement doesn't have to be repeated
    /// </summary>
    /// <returns>List with the tags of tiles where a building of buildingType can be placed</returns>
    List<string> TilesBuildingCanBePlaced(Buildings.Type buildingType)
    {
        List<string> answer = new List<string>(2);
        answer.Add("PisoTipo3"); //so far, all buildings can be built in PisoTipo3
        //if (buildingType == Buildings.Type.TrashTruckStation)
        //{
        //}
        return answer;
    }
}
