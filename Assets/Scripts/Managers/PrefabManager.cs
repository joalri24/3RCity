using UnityEngine;

public class PrefabManager : MonoBehaviour {

    [Header("Buildables")]

    [SerializeField]
    GameObject trashTruckStationPrefab;
    //[SerializeField]
    //GameObject landfillPrefab;

    //[Header("Trash")]

    //[SerializeField]
    //GameObject trash;

    //[Header("Trucks")]

    //[SerializeField]
    //GameObject regularTrashTruck;

    public GameObject MapBuildingToPrefab(Buildings.Type building)
    {
        GameObject answer = null;
        if (building == Buildings.Type.TrashTruckStation)
        {
            answer = trashTruckStationPrefab;
        }
        return answer;
    }

    /// <summary>
    /// Returns renderer of instantiated GameObject. Exists so code to get the renderer of a certain
    /// type of building doesn't have to be repeated.
    /// </summary>
    public Renderer MapBuildingToRenderer(Buildings.Type building, GameObject buildingObject)
    {
        Renderer answer = null;
        if (building == Buildings.Type.TrashTruckStation)
        {
            answer = buildingObject.transform.Find("Model").gameObject.GetComponent<Renderer>();
        }
        return answer;
    }

    //public GameObject TrashPrefab()
    //{
    //    return trash;
    //}

    //public GameObject TrashTruckPrefab()
    //{
    //    return regularTrashTruck;
    //}
}
