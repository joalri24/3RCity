using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInit : MonoBehaviour {
    public Transform canvas;
    public Transform panelInformacion;
    private EstadoJuego estado;
    private Text textoInformativo;
    public Transform panelPublicidad;
	// Use this for initialization
	void Start ()
    {
        estado = EstadoJuego.InstanciaEstadoJuego;
        textoInformativo = (Text)panelInformacion.GetChild(0).GetComponent<Text>();
        panelInformacion.gameObject.SetActive(false);
    }

    public IEnumerator mostrarYBorrar()
    {
            estado.HayMensaje = true;
            textoInformativo.text = estado.MensajeInformacion;
            panelInformacion.gameObject.SetActive(true);
            yield return new WaitForSeconds(4f);
            estado.HayMensaje = false;
            panelInformacion.gameObject.SetActive(false);
    }	
}
