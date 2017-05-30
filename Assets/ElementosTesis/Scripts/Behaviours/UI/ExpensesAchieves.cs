using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpensesAchieves : MonoBehaviour {

    public Button btnPremio;
    public Button btnPremio1;

    private EstadoJuego estado;

	// Use this for initialization
	void Start () {
        btnPremio.onClick.AddListener(restarCantidadDinero);
        btnPremio1.onClick.AddListener(restarCantidadDinero1);
        estado = EstadoJuego.InstanciaEstadoJuego;
	}
	
	// Update is called once per frame
	void restarCantidadDinero () {
        estado.CantidadDinero -= 250;
        estado.Expense -= 250;
	}

    void restarCantidadDinero1()
    {
        estado.CantidadDinero -= 300;
        estado.Expense -= 300;
    }
}
