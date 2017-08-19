using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesInteraccion : MonoBehaviour {


    public int dineroNecesitado;
    private EstadoJuego estado;
    public bool noAplica;
    public bool aplica;
    public bool aplicaPremio1;
    public bool aplicaPremio2;
    public bool aplicaPub1;
    public bool aplicaPub2;
    private static bool notInteractable;
    public static bool activarPublicidad2;
    public static bool activarPublicidad3;
    void Start()
    {
        activarPublicidad2 = false;
        activarPublicidad3 = false;
        estado = EstadoJuego.InstanciaEstadoJuego;
    }

    public static void NotInteractable(bool set)
    {
        notInteractable = set;
    }
	// Update is called once per frame
	void Update () {
        if (notInteractable)
        {
                noAplica = false;
                this.GetComponent<Button>().interactable = false;
        }
        else if (noAplica)
        {
            if (estado.CantidadDinero >= dineroNecesitado)
            {
                this.GetComponent<Button>().interactable = true;
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
        else if (aplicaPremio1)
        {
            if (estado.CantidadDinero >= dineroNecesitado && GameObject.FindGameObjectWithTag("Parque")!=null)
            {
                this.GetComponent<Button>().interactable = true;
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
        else if (aplicaPremio2)
        {
            if (estado.CantidadDinero >= dineroNecesitado && GameObject.FindGameObjectWithTag("Museo") != null)
            {
                this.GetComponent<Button>().interactable = true;
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
        else if (aplicaPub1)
        {
            if (estado.CantidadDinero >= dineroNecesitado && activarPublicidad2== true)
            {
                this.GetComponent<Button>().interactable = true;
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
        else if (aplicaPub2)
        {
            if (estado.CantidadDinero >= dineroNecesitado && activarPublicidad3 == true)
            {
                this.GetComponent<Button>().interactable = true;
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
        else if(aplica)
        {
            if (estado.CantidadDinero >= dineroNecesitado && BuildingSpawn.OrdInit == 1 && BuildingSpawn.publicidad == 1)
            {
                this.GetComponent<Button>().interactable = true;
            }
            else
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            this.GetComponent<Button>().interactable = false;
        }
        
	}
}
