using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartEverythingBehaviour : MonoBehaviour {

    public Button botonRestart;
    public Button botonVolver;
    private Ciudad nuevaCiudad;
    private EstadoJuego nuevoEstado;
	// Use this for initialization
	void Start () {
        nuevaCiudad = Ciudad.InstanciaCiudad;
        nuevoEstado = EstadoJuego.InstanciaEstadoJuego;
        botonRestart.onClick.AddListener(restart);
        botonVolver.onClick.AddListener(volverMenu);
    }
	
	void restart()
    {
        nuevaCiudad.borrarTodo();
        nuevoEstado.borrarEstado();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    void volverMenu()
    {
        nuevaCiudad.borrarTodo();
        nuevoEstado.borrarEstado();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
