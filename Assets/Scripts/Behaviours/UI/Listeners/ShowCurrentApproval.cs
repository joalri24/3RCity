using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowCurrentApproval : MonoBehaviour, IApprovalChangedListener {

    Text approvalText;

	void Start () {
        approvalText = GetComponent<Text>();
        //EstadoJuego.InstanciaEstadoJuego.addOnApprovalChangedListener(this);
	}
	
    void IApprovalChangedListener.onApprovalChanged()
    {
        //approvalText.text = EstadoJuego.InstanciaEstadoJuego.Approval + "%";
    }
}
