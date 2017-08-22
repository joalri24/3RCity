﻿// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Handles logic related to camera movement. 
/// </summary>
public class MoveCamera : MonoBehaviour
{
    //
    // VARIABLES
    //
    public float turnSpeed = 3.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f;      // Speed of the camera going back and forth
    public Button botonReset;

    private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
    private bool isPanning;     // Is the camera being panned?
    private bool isRotating;    // Is the camera being rotated?
    private bool isZooming;     // Is the camera zooming?
    private Vector3 posIni;
    private Quaternion rotIni;

    void Start()
    {
        rotIni = this.transform.rotation;
        posIni = this.transform.position;
        botonReset.GetComponent<Button>().onClick.AddListener(resetCamera);
    }
    //
    // UPDATE
    //
    void resetCamera()
    {
        this.transform.position = posIni;
        this.transform.rotation = rotIni;
    }
    void Update()
    {
        // Get the left mouse button
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // Get mouse origin
        //    mouseOrigin = Input.mousePosition;
        //    isRotating = true;
        //}

        // Get the right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        // Get the middle mouse button
        if (Input.GetMouseButtonDown(2))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isZooming = true;
        }

        // Disable movements on button release
        if (!Input.GetMouseButton(0)) isRotating = false;
        if (!Input.GetMouseButton(1)) isPanning = false;
        if (!Input.GetMouseButton(2)) isZooming = false;

        // Rotate camera along X and Y axis
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }

        // Move the camera on it's XY plane
        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
            transform.Translate(move, Space.Self);
        }

        // Move the camera linearly along Z axis
        if (isZooming)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = pos.y * zoomSpeed * transform.forward;
            transform.Translate(move, Space.World);
        }

        //if (this.transform.position.x >=85f &&)
        //{

        //}
    }
}