using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EstadoJuego {
    //Elementos del Singleton
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
    private Ciudad city;

    EstadoJuego()
    {
        nivelEducacion = 0;
        elementoSeleccionadoUI = 0;
        mensajeInformacion = "";
        hayMensaje = false;
        city = Ciudad.InstanciaCiudad;
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
        float prom = city.NumBasuraSinRecoger / 5;
            int egre1 = 0;
        if (city.NumBasuraSinRecoger > 100 && city.NumBasuraSinRecoger<=200)
        {
            egre1 = (int)(prom * (prom / city.NumBasuraSinRecoger));
        }
        else if (city.NumBasuraSinRecoger > 200 && city.NumBasuraSinRecoger <= 300)
        {
            egre1 = (int)(prom * (prom / (city.NumBasuraSinRecoger*1.65)));
        }
        else if (city.NumBasuraSinRecoger > 300 && city.NumBasuraSinRecoger <= 400)
        {
            egre1 = (int)(prom * 0.55f);
        }
        else
        {
            egre1 = (int)(prom * 0.75f);
        }
         
        cantidadDinero -= egre1;
        expense -= egre1;
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
