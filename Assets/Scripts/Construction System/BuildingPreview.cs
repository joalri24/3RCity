using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour {

    public LayerMask placeableLayerMask;

    [Tooltip("Layers where objects would prevent building from being placed")]
    public LayerMask obstacleLayerMask; //Inefficient! But this is a prototype

    Buildings.Type previewingBuildingType;
    GameObject previewingBuilding;
    Renderer previewingRenderer;

    bool isPreviewPlaceable;
    Color originalBuildingColor;

    void Update()
    {
        if (IsMouseInViewport())
        {
            PreviewBuilding();
            HandlePlayerClick();
        }
    }
    
    void PreviewBuilding()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //TODO - Note: Just to preview it isn't necessary to actually raycast every frame,
        // it only needs to translate preview aligned with the camera container's
        // local X and Z axes, with the constant Y of the City plane + previewingObjectHeight/2
        if (Physics.Raycast(mouseRay, out hit, 200, placeableLayerMask)) 
        {
            previewingBuilding.transform.position = hit.point;
            isPreviewPlaceable = (!Physics.Raycast(mouseRay, 200, obstacleLayerMask)) && Managers.Instance.BuildingPlacement.
                            CanBuildingBePlacedInTile(previewingBuildingType, hit.collider.tag);
            if (isPreviewPlaceable)
            {
                //Note: using only .material might not work for more complicated models, have to update in
                //the future
                previewingRenderer.material.SetColor("_Color", Color.green);
                previewingRenderer.transform.position =
                    new Vector3(hit.collider.gameObject.transform.position.x + 1.8f,
                                hit.collider.gameObject.transform.position.y,
                                hit.collider.gameObject.transform.position.z + 2f); //should actually fix prefabs
                            //instead but that would mess up level generation
            }
            else
            {
                previewingRenderer.material.SetColor("_Color", Color.red);
            }
        }
    }

    void HandlePlayerClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPreviewPlaceable)
            {
                previewingRenderer.material.color = originalBuildingColor;
                Managers.Instance.BuildingPlacement.Place(previewingBuildingType, previewingBuilding);
            }
            else
            {
                //give feedback that building can't be placed, like playing a sound
            }
        } 
        //Cancel placement
        if (Input.GetMouseButtonDown(1))
        {
            CancelPreview();
        }
    }

	public void StartBuildingPreview(Buildings.Type buildingType)
    {
        previewingBuildingType = buildingType;
        previewingBuilding = Managers.Instance.PrefabManager.MapBuildingToPrefab(buildingType);
        previewingBuilding = Instantiate(previewingBuilding, new Vector3(-100f, -100f, -100f), Quaternion.identity);
        previewingRenderer = previewingBuilding.transform.Find("Model").gameObject.GetComponent<Renderer>();
        originalBuildingColor = previewingRenderer.material.color;
        enabled = true;
    }

    public void StopPreview()
    {
        enabled = false;
    }

    bool IsMouseInViewport()
    {
        return Input.mousePosition.x >= 0f && Input.mousePosition.y >= 0f
            && Input.mousePosition.x <= Screen.width && Input.mousePosition.y <= Screen.height;
    }

    void CancelPreview()
    {
        Destroy(previewingBuilding);
        StopPreview();
    }
}
