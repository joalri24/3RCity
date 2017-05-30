using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioEdificio : MonoBehaviour {

    public Transform museo;
    public Transform parque;
    private EstadoJuego estadoActual;
    public Button botonFabrica;
    public Button botonPublicidad;
    public Button botonFabrica1;
    public Button botonFabrica2;
    public Button botonFabrica3;
    public Button botonParque;
    public Button botonMuseo;

    //Inicializacion de botones
    void Start()
    {
        estadoActual = EstadoJuego.InstanciaEstadoJuego;
        Button btn1 = botonFabrica.GetComponent<Button>();
        Button btn2 = botonPublicidad.GetComponent<Button>();
        Button btn3 = botonFabrica1.GetComponent<Button>();
        Button btn4 = botonFabrica2.GetComponent<Button>();
        Button btn5 = botonFabrica3.GetComponent<Button>();
        Button btn6 = botonParque.GetComponent<Button>();
        btn1.onClick.AddListener(cambioAFabrica);
        btn2.onClick.AddListener(cambioAEdificioPublicidad);
        btn3.onClick.AddListener(cambioAEdificioPapel);
        btn4.onClick.AddListener(cambioAEdificioPlastico);
        btn5.onClick.AddListener(cambioAEdificioVidrio);
        btn6.onClick.AddListener(añadirParque);

        Button btn7 = botonMuseo.GetComponent<Button>();
        btn7.onClick.AddListener(añadirMuseo);
    }
    void cambioAFabrica()
    {
        estadoActual.ElementoSeleccionadoUI = 2;
    }

    void cambioAEdificioPublicidad()
    {
        estadoActual.ElementoSeleccionadoUI = 3;
    }
    void cambioAEdificioPapel()
    {
        estadoActual.ElementoSeleccionadoUI = 4;
    }
    void cambioAEdificioPlastico()
    {
        estadoActual.ElementoSeleccionadoUI = 5;
    }
    void cambioAEdificioVidrio()
    {
        estadoActual.ElementoSeleccionadoUI = 6;
    }

    void añadirParque()
    {
        Instantiate(parque, new Vector3(24, 0, 20), Quaternion.identity);
    }

    void añadirMuseo()
    {
        Instantiate(museo, new Vector3(26, 0, 6), Quaternion.identity);
    }

}
