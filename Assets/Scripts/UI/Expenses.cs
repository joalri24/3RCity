using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Expenses : MonoBehaviour {

    Text txt;
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
        txt.text = "" + estado.Expense;
    }
}
