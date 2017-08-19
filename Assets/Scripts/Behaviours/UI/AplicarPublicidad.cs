using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AplicarPublicidad : MonoBehaviour {

    public Button botonAplicar;
    private EstadoJuego estado;
    public static int numMensaje;
    public PanelPublicidad panelPublicidad;
	// Use this for initialization
	void Start () {
        estado = EstadoJuego.InstanciaEstadoJuego;
        botonAplicar.GetComponent<Button>().onClick.AddListener(aplicarEstrategia1);
    }
	void aplicarEstrategia1()
    {
        if (numMensaje == 1)
        {
            estado.NivelEducacion += 5;
            panelPublicidad.btnPublicidad0.interactable = false;
            panelPublicidad.btnPublicidad0.GetComponentInChildren<Text>().text = "Ya aplicaste esta estrategia!";
            BotonesInteraccion.activarPublicidad2 = true;
        }
        else if (numMensaje == 2)
        {
            estado.NivelEducacion += 10;
            SpawnBasuraBehaviour.tiempoSpawnPapel -= 1.25f;
            SpawnBasuraBehaviour.tiempoSpawnPlastico -= 0.75f;
            SpawnBasuraBehaviour.tiempoSpawnVidrio -= 0.75f;
            SpawnBasuraBehaviour.tiempoSpawnOrdinario += 0.5f;
            panelPublicidad.btnPublicidad1.interactable = false;
            panelPublicidad.btnPublicidad1.GetComponentInChildren<Text>().text = "Ya aplicaste esta estrategia!";
            BotonesInteraccion.activarPublicidad2 = false;
            BotonesInteraccion.activarPublicidad3 = true;
            estado.CantidadDinero -= 50;
        }

        else if (numMensaje == 3)
        {
            estado.NivelEducacion += 15;
            SpawnBasuraBehaviour.tiempoSpawnPapel -= 1.75f;
            SpawnBasuraBehaviour.tiempoSpawnPlastico -= 1f;
            SpawnBasuraBehaviour.tiempoSpawnVidrio -= 1f;
            SpawnBasuraBehaviour.tiempoSpawnOrdinario += 1f;
            panelPublicidad.btnPublicidad2.interactable = false;
            panelPublicidad.btnPublicidad2.GetComponentInChildren<Text>().text = "Ya aplicaste esta estrategia!";
            BotonesInteraccion.activarPublicidad3 = false;
            estado.CantidadDinero -= 50;
        }
        else if (numMensaje == 4)
        {
            estado.NivelEducacion += 30;
            SpawnBasuraBehaviour.tiempoSpawnPapel -= 2.5f;
            SpawnBasuraBehaviour.tiempoSpawnPlastico -= 1.5f;
            SpawnBasuraBehaviour.tiempoSpawnVidrio -= 1.5f;
            SpawnBasuraBehaviour.tiempoSpawnOrdinario += 1.65f;
            panelPublicidad.btnPublicidad3.interactable = false;
            panelPublicidad.btnPublicidad3.GetComponentInChildren<Text>().text = "Ya aplicaste esta estrategia!";
            estado.CantidadDinero -= 150;
        }
        else if (numMensaje == 5)
        {
            estado.NivelEducacion += 40;
            SpawnBasuraBehaviour.tiempoSpawnPapel -= 3f;
            SpawnBasuraBehaviour.tiempoSpawnPlastico -= 2f;
            SpawnBasuraBehaviour.tiempoSpawnVidrio -= 2f;
            SpawnBasuraBehaviour.tiempoSpawnOrdinario += 3.5f;
            panelPublicidad.btnPublicidad4.interactable = false;
            panelPublicidad.btnPublicidad4.GetComponentInChildren<Text>().text = "Ya aplicaste esta estrategia!";
            estado.CantidadDinero -= 200;
        }

    }
}
