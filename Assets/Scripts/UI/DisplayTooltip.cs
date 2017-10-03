﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject tooltip;
    public bool followMouse;

    void Start() {
        followMouse = tooltip.GetComponent<FollowMouse>() != null;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("DisplayTooltip.OnPointerEnter");
        if (followMouse) {
            tooltip.transform.position = Input.mousePosition;
        }
        tooltip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        tooltip.SetActive(false);
    }
}
