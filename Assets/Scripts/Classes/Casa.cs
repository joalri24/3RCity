using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Casa :IGeneradora {

    public static int NUM_MAX_BASURA = 15;
    private int numBasuraGeneral;
    private int numBasuraPapel;
    private int numBasuraVidrio;
    private int numBasuraPlastico;
    private bool llena;
    private bool llenaPapel;
    private bool llenaPlastico;
    private bool llenaVidrio;
    private float posicionX;
    private float posicionZ;
    private bool enVisita;
    private List<Basura> basuraAcumulada;
    private List<Basura> papelAcumulado;
    private List<Basura> vidrioAcumulado;
    private List<Basura> plasticoAcumulado;

    public Casa(float posX, float posZ)
    {
        llena = false;
        posicionX = posX;
        posicionZ = posZ;
        enVisita = false;
        basuraAcumulada = new List<Basura>();
        papelAcumulado = new List<Basura>();
        vidrioAcumulado = new List<Basura>();
        plasticoAcumulado = new List<Basura>();
    }

        
    public int NumBasuraGeneral
    {
        get{return numBasuraGeneral;}
        set{numBasuraGeneral = value;}
    }
    public int NumBasuraPapel
    {
        get { return numBasuraPapel; }
        set { numBasuraPapel = value; }
    }
    public int NumBasuraVidrio
    {
        get { return numBasuraVidrio; }
        set { numBasuraVidrio = value; }
    }
    public int NumBasuraPlastico
    {
        get { return numBasuraPlastico; }
        set { numBasuraPlastico = value; }
    }

    public float PosicionEnX
    {
        get { return posicionX; }
    }
    public float PosicionEnZ
    {
        get { return posicionZ; }
    }

    public void generar()
    {
        if (numBasuraGeneral<NUM_MAX_BASURA) { numBasuraGeneral++;}
    }
    public void generarPapel()
    {
        if (numBasuraPapel < NUM_MAX_BASURA) { numBasuraPapel++; }
    }
    public void generarPlastico()
    {
        if (numBasuraPlastico < NUM_MAX_BASURA) { numBasuraPlastico++; }
    }
    public void generarVidrio()
    {
        if (numBasuraVidrio < NUM_MAX_BASURA) { numBasuraVidrio++; }
    }

    public bool estaLlena()
    {
        if (numBasuraGeneral< NUM_MAX_BASURA){ llena = false;}
        else{ llena = true;}
        return llena;
    }
    public bool estaLlenaPapel()
    {
        if (numBasuraPapel < NUM_MAX_BASURA) { llenaPapel = false; }
        else { llenaPapel = true; }
        return llenaPapel;
    }
    public bool estaLlenaPlastico()
    {
        if (numBasuraPlastico < NUM_MAX_BASURA) { llenaPlastico = false; }
        else { llenaPlastico = true; }
        return llenaPlastico;
    }
    public bool estaLlenaVidrio()
    {
        if (numBasuraVidrio < NUM_MAX_BASURA) { llenaVidrio = false; }
        else { llenaVidrio = true; }
        return llenaVidrio;
    }

    public bool EnVisita
    {
        get { return enVisita; }
        set { enVisita = value; }
    }

    public bool noHayBasura()
    {
        if (numBasuraGeneral==0){ return true;}
        return false;
    }
    public bool noHayPapel()
    {
        if (numBasuraPapel == 0) { return true; }
        return false;
    }
    public bool noHayVidrio()
    {
        if (numBasuraVidrio == 0) { return true; }
        return false;
    }
    public bool noHayPlastico()
    {
        if (numBasuraPlastico == 0) { return true; }
        return false;
    }


    public List<Basura> darBasuraAcumulada()
    {
        return basuraAcumulada;
    }

    public List<Basura> darPapelAcumulado()
    {
        return papelAcumulado;
    }
    public List<Basura> darPlasticoAcumulado()
    {
        return plasticoAcumulado;
    }
    public List<Basura> darVidrioAcumulado()
    {
        return vidrioAcumulado;
    }


    public void añadirBasura(Basura basurita)
    {     
        basuraAcumulada.Add(basurita);
    }
    public void añadirPapel(Basura basurita)
    {
        papelAcumulado.Add(basurita);
    }
    public void añadirPlastico(Basura basurita)
    {
        plasticoAcumulado.Add(basurita);
    }
    public void añadirVidrio(Basura basurita)
    {
        vidrioAcumulado.Add(basurita);
    }
}
