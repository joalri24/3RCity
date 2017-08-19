using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camion
{

    public static int MAX_CAPACIDAD = 7;
    private int llenado;
    private int loRecogido;
    private int loRecogidoPapel;
    private int loRecogidoVidrio;
    private int loRecogidoPlastico;
    private bool estaEnCamino;

    // Use this for initialization
    public Camion(Fabrica origen)
    {
        llenado = 0;
        estaEnCamino = false;
    }

    public bool EstaEnCamino
    {
        get { return estaEnCamino; }
        set { estaEnCamino = value; }
    }

    public int LoRecogido
    { get { return loRecogido; }  }

    public int LoRecogidoPapel
    { get { return loRecogidoPapel; } }

    public int LoRecogidoPlastico
    { get { return loRecogidoPlastico; } }

    public int LoRecogidoVidrio
    { get { return loRecogidoVidrio; } }

    public int Llenado
    {
        get { return llenado; }
        set { llenado = value; }
    }

    public bool estaFull()
    {
        if (llenado<MAX_CAPACIDAD)
        {
            return false;
        }
        return true;
    }

    public void recoger(Casa visitaCasa)
    {
        
        if (MAX_CAPACIDAD>llenado)
        {
            int faltaParaLlenar = MAX_CAPACIDAD - llenado;
            if (faltaParaLlenar>visitaCasa.NumBasuraGeneral)
            {
                loRecogido = visitaCasa.NumBasuraGeneral;
                llenado += visitaCasa.NumBasuraGeneral; 
                visitaCasa.NumBasuraGeneral = 0;
                 
            }
            else
            {
                loRecogido = faltaParaLlenar;
                llenado += faltaParaLlenar;
                visitaCasa.NumBasuraGeneral -= faltaParaLlenar;
            }
            
        }
        
    }
    public void recogerPapel(Casa visitaCasa)
    {

        if (MAX_CAPACIDAD > llenado)
        {
            int faltaParaLlenar = MAX_CAPACIDAD - llenado;
            if (faltaParaLlenar > visitaCasa.NumBasuraPapel)
            {
                loRecogidoPapel = visitaCasa.NumBasuraPapel;
                llenado += visitaCasa.NumBasuraPapel;
                visitaCasa.NumBasuraPapel = 0;

            }
            else
            {
                loRecogidoPapel = faltaParaLlenar;
                llenado += faltaParaLlenar;
                visitaCasa.NumBasuraPapel -= faltaParaLlenar;
            }

        }

    }
    public void recogerVidrio(Casa visitaCasa)
    {

        if (MAX_CAPACIDAD > llenado)
        {
            int faltaParaLlenar = MAX_CAPACIDAD - llenado;
            if (faltaParaLlenar > visitaCasa.NumBasuraVidrio)
            {
                loRecogidoVidrio = visitaCasa.NumBasuraVidrio;
                llenado += visitaCasa.NumBasuraVidrio;
                visitaCasa.NumBasuraVidrio = 0;

            }
            else
            {
                loRecogidoVidrio = faltaParaLlenar;
                llenado += faltaParaLlenar;
                visitaCasa.NumBasuraVidrio -= faltaParaLlenar;
            }

        }

    }

    public void recogerPlastico(Casa visitaCasa)
    {

        if (MAX_CAPACIDAD > llenado)
        {
            int faltaParaLlenar = MAX_CAPACIDAD - llenado;
            if (faltaParaLlenar > visitaCasa.NumBasuraPlastico)
            {
                loRecogidoPlastico = visitaCasa.NumBasuraPlastico;
                llenado += visitaCasa.NumBasuraPlastico;
                visitaCasa.NumBasuraPlastico = 0;

            }
            else
            {
                loRecogidoPlastico = faltaParaLlenar;
                llenado += faltaParaLlenar;
                visitaCasa.NumBasuraPlastico -= faltaParaLlenar;
            }

        }

    }
}
