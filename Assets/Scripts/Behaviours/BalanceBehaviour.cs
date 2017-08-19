using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBehaviour : MonoBehaviour {

    private EstadoJuego estado;
    private float lastUpdate;
	// Use this for initialization
	void Start () {
        estado = EstadoJuego.InstanciaEstadoJuego;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastUpdate >= 3.25f)
        {
            estado.egresosBalance();
            lastUpdate = Time.time;
        }
	}
}
