using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCondition : MonoBehaviour {

    private MoveCamera move;
    public Camera mainCamera;
    private EstadoJuego estado;
    private float lastUpdate;
    public GameObject panelGameOver;
    public GameObject panelDarkScreen;
    // Use this for initialization
    void Start ()
    {
        move = mainCamera.GetComponent<MoveCamera>();
        estado = EstadoJuego.InstanciaEstadoJuego;
        lastUpdate = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (estado.CantidadDinero <=-50 && lastUpdate == 0)
        {
            lastUpdate = Time.time;
        }
        else if (estado.CantidadDinero > -50 && lastUpdate != 0)
        {
            lastUpdate = 0;
        }


        if (Time.time >= lastUpdate + 10f && lastUpdate !=0)
        {
            move.turnSpeed = 0;
            move.panSpeed = 0;
            move.zoomSpeed = 0;
            panelDarkScreen.SetActive(true);
            panelGameOver.SetActive(true);
            Time.timeScale = 0;

        }
	}
}
