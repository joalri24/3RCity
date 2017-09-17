using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {

    BuildingPreview buildingPreview;

    void Start()
    {
        buildingPreview = GetComponent<BuildingPreview>();
    }

    public void Place(Buildings.Type buildingType, GameObject buildingInstance)
    {
        //play building sound or something
        buildingInstance.layer = Buildings.Layer;
        if (buildingType == Buildings.Type.TrashTruckStation)
        {
            buildingInstance.transform.Find("Model").gameObject.layer = Buildings.Layer;
            buildingInstance.GetComponent<TrashTruckStationAI>().BeginOperations();
        }
        buildingPreview.StopPreview();
    }

	public void PreviewBuilding(Buildings.Type buildingType)
    {
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
    List<string> TilesBuildingCanBePlaced(Buildings.Type buildingType)
    {
        List<string> answer = new List<string>(2);
        if (buildingType == Buildings.Type.TrashTruckStation)
        {
            answer.Add("PisoTipo3");
        }
        return answer;
    }
}
