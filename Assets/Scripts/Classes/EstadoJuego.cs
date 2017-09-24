using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EstadoJuego {

    private static EstadoJuego instance = null;
    private static readonly object padlock = new object();
    private int elementoSeleccionadoUI;
    private string mensajeInformacion;
    private bool hayMensaje;
    private int nivelEducacion;
    private int numeroBasuraEnCasa;
    private int numPapelReciclado;
    private int cantidadDinero;
    private float income;
    private float expense;
    private City currentCity;

    EstadoJuego()
    {
        nivelEducacion = 0;
        elementoSeleccionadoUI = 0;
        mensajeInformacion = "";
        hayMensaje = false;
    }

    public static EstadoJuego InstanciaEstadoJuego
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new EstadoJuego();
                }
                return instance;
            }
        }
    }


    public int ElementoSeleccionadoUI
    {
        get { return elementoSeleccionadoUI; }

        set { elementoSeleccionadoUI = value; }
    }

    public string MensajeInformacion
    {
        get { return mensajeInformacion; }
        set { mensajeInformacion = value; }
    }
    public bool HayMensaje
    {
        get { return hayMensaje; }
        set { hayMensaje = value; }
    }

    public int NivelEducacion
    {
        get { return nivelEducacion; }
        set { nivelEducacion = value; }
    }

    public int CantidadDinero
    {
        get { return cantidadDinero; }
        set { cantidadDinero = value; }
    }

    public float Income
    {
        get { return income; }
        set { income = value; }
    }

    public float Expense
    {
        get { return expense; }
        set { expense = value; }
    }

    public void egresosBalance()
    {
    }

    public void borrarEstado()
    {
        nivelEducacion = 0;
        elementoSeleccionadoUI = 0;
        mensajeInformacion = "";
        hayMensaje = false;
        income = 0;
        expense = 0;
        cantidadDinero = 0;
    }
}
