using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : IBasura
{
    public static int ORGANICA = 0;
    public static int PAPEL_CARTON = 1;
    public static int VIDRIO = 2;
    public static int PLASTICOS_LATAS = 3;
    private GameObject gOCorrespondiente;
    private int tipoBasura;

    public Basura(int _tipoBasura, GameObject correspondiente)
    {
        tipoBasura = _tipoBasura;
        gOCorrespondiente = correspondiente;
    }

    public int darTipo()
    {
        return tipoBasura;
    }

    public GameObject darGameobject()
    {
        return gOCorrespondiente;
    }
}
