using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton representando la ciudad actual
/// </summary>
public class Ciudad
{
    private static Ciudad instance = null;
    private static readonly object padlock = new object();
    private ArrayList casasEnCiudad;
    private ArrayList fabricasEnCiudad;
    private int numBasuraSinRecoger;
    private int numOrdinarioRecogido;
    private int numPapelRecogido;
    private int numPlasticoRecogido;
    private int numVidrioRecogido;

    public static Ciudad InstanciaCiudad
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Ciudad();
                }
                return instance;
            }
        }
    }

    public Ciudad()
    {
        casasEnCiudad = new ArrayList();
        fabricasEnCiudad = new ArrayList();
        numBasuraSinRecoger = 0;
    }

    public void añadirCasa(Casa casaTemp)
    {
        casasEnCiudad.Add(casaTemp);
    }

    public void añadirFabrica(Fabrica fabricaTemp)
    {
        fabricasEnCiudad.Add(fabricaTemp);
    }

    public int darNumCasas()
    {
        return casasEnCiudad.Count;
    }
    public int darNumFabricas()
    {
        return fabricasEnCiudad.Count;
    }

    public Casa buscarCasa(float x, float z)
    {
        for (int i = 0; i < casasEnCiudad.Count; i++)
        {
            Casa temporal = (Casa)casasEnCiudad[i];
            if (temporal.PosicionEnX==x&&temporal.PosicionEnZ==z)
            {
                return temporal;
            }
        }
        return null;
    }

    public ArrayList darCasas()
    {
        return casasEnCiudad;
    }

    public ArrayList darFabricas()
    {
        return fabricasEnCiudad;
    }

    public Fabrica buscarFabrica(float x, float z)
    {
        for (int i = 0; i < fabricasEnCiudad.Count; i++)
        {
            Fabrica temporal = (Fabrica)fabricasEnCiudad[i];
            if (temporal.PosicionX == x && temporal.PosicionZ == z)
            {
                return temporal;
            }
        }
        return null;
    }
    public int NumBasuraSinRecoger
    {
        get { return numBasuraSinRecoger; }
        set { numBasuraSinRecoger = value; }
    }
    public int NumBasuraRecogida
    {
        get { return numOrdinarioRecogido; }
        set { numOrdinarioRecogido = value; }
    }
    public int NumPapelReciclado
    {
        get { return numPapelRecogido; }
        set { numPapelRecogido = value; }
    }
    public int NumPlasticoReciclado
    {
        get { return numPlasticoRecogido; }
        set { numPlasticoRecogido = value; }
    }
    public int NumVidrioReciclado
    {
        get { return numVidrioRecogido; }
        set { numVidrioRecogido = value; }
    }

    public void borrarTodo()
    {
        numBasuraSinRecoger = 0;
        casasEnCiudad = new ArrayList();
        fabricasEnCiudad = new ArrayList();
        numOrdinarioRecogido = 0;
        numPapelRecogido = 0;
        numVidrioRecogido = 0;
        numPlasticoRecogido = 0;
    }
}
