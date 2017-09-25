using UnityEngine;

public class PrefabManager : MonoBehaviour {

    [Header("Buildables")]

    [SerializeField]
    private GameObject trashTruckStationPrefab;

    [SerializeField]
    private GameObject paperRecyclingCenterPrefab;

    [SerializeField]
    private GameObject glassRecyclingCenterPrefab;

    [SerializeField]
    private GameObject metalRecyclingCenterPrefab;

    //[SerializeField]
    //GameObject landfillPrefab;

    //[Header("Trash")]

    //[SerializeField]
    //GameObject trash;

    [Header("Trucks")]

    [SerializeField]
    GameObject regularTrashTruck;

    public GameObject MapBuildingToPrefab(Buildings.Type building)
    {
        GameObject answer = null;
        if (building == Buildings.Type.TrashTruckStation) {
            answer = trashTruckStationPrefab;
        }
        else if (building == Buildings.Type.PaperRecyclingCenter) {
            answer = paperRecyclingCenterPrefab;
        } 
        else if (building == Buildings.Type.GlassRecyclingCenter) {
            answer = glassRecyclingCenterPrefab;
        } 
        else if (building == Buildings.Type.MetalRecyclingCenter) {
            answer = metalRecyclingCenterPrefab;
        }
        return answer;
    }

    public GameObject TrashTruckPrefab()
    {
        return regularTrashTruck;
    }
}
