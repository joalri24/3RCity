using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabrica
{
    private Camion[] camiones;
    private float posX;
    private float posZ;
    private int cantidadRecogida;
    private String tipoFabrica;

    public Fabrica(float _posX, float _posZ, String _tipoFabrica)
    {
        posX = _posX;
        posZ = _posZ;
        camiones = new Camion[5];
        tipoFabrica = _tipoFabrica;
    }
    public float PosicionX { get { return posX; } }
    public float PosicionZ { get { return posZ; } }
    public int CantidadRecogida
    {
        get { return cantidadRecogida; }
        set { cantidadRecogida = value; }
    }
    public Camion[] darCamionesFabrica()
    {
        return camiones;
    }
    public void añadirCamion(Camion añadir)
    {
        for (int i = 0; i < camiones.Length; i++)
        {
            if (camiones[i]==null)
            {
                camiones[i] = añadir;
            }   
        }
    }
    public String TipoFabrica { get { return tipoFabrica; }   }
}
