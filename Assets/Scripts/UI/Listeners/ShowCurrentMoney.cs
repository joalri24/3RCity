using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowCurrentMoney : MonoBehaviour, IMoneyChangedListener {

    Text moneyText;

    void Start()
    {
        moneyText = gameObject.GetComponent<Text>();
        //EstadoJuego.InstanciaEstadoJuego.addOnMoneyChangedListener(this);
        ((IMoneyChangedListener)this).onMoneyChanged();
    }

    public void onMoneyChanged()
    {
        moneyText.text = "" + EstadoJuego.InstanciaEstadoJuego.CantidadDinero;
    }
}
