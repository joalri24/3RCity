using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DineroActual : MonoBehaviour {

    Text txt;
    public int currentscore;
    private EstadoJuego estado;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        estado = EstadoJuego.InstanciaEstadoJuego;
    }

    // Update is called once per frame
    void Update()
    {
        currentscore = estado.CantidadDinero;
        txt.text = "" + currentscore;
    }
}
