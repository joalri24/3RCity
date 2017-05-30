using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BuildingSpawn : MonoBehaviour {

    public Button botonPremios;
    public Button botonPublicidad;
    public Transform edif0;
    public Transform edif1;
    public Transform edif2;
    public Transform edifPapel;
    public Transform edifPlastico;
    public Transform edifVidrio;
    public GameObject camionBase;
    public Transform camionPapel;
    public Transform camionPlastico;
    public Transform camionVidrio;
    public AudioClip contructionAudio;


    private bool initCamiones;
    RaycastHit vHit;
    Ray vRay;
    Vector3 position_Click;
    private UIInit uiMessage;
    private EstadoJuego estado;
    private Ciudad unicaCiudad;
    public static int OrdInit;
    private int PapelInit;
    private int PlasticoInit;
    private int VidrioInit;
    public static int publicidad;
    //Inicialización de ciudad
    void Start()
    {
        OrdInit = 0;
        PapelInit = 0;
        VidrioInit = 0;
        PlasticoInit = 0;
        publicidad = 0;
        initCamiones = false;
        uiMessage = FindObjectOfType<UIInit>();
        GameObject[] casasTemp = GameObject.FindGameObjectsWithTag("Casa");
        unicaCiudad = Ciudad.InstanciaCiudad;
        estado = EstadoJuego.InstanciaEstadoJuego;
        estado.CantidadDinero = 400;
        for (int i = 0; i < casasTemp.Length; i++)
        {
            float posx = casasTemp[i].transform.position.x;
            float posz = casasTemp[i].transform.position.z;
            Casa temp = new Casa(posx,posz);
            unicaCiudad.añadirCasa(temp);
        }
        vHit = new RaycastHit();
    }

    // Update is called once per frame
    void Update()
    {
        if (estado.NivelEducacion>=5 && !initCamiones)
        {
            inicializarCamiones();
        }

        if (unicaCiudad.NumPapelReciclado >=50 && unicaCiudad.NumPlasticoReciclado >= 50 && unicaCiudad.NumVidrioReciclado >= 50 && OrdInit ==1 && PlasticoInit == 1 && VidrioInit == 1 && PapelInit == 1)
        {
            botonPremios.interactable = true;
        }

        if (estado.ElementoSeleccionadoUI == 2)
        {
            edifSeleccionado(edif1,1,4,"Fabrica1");
        }
        else if (estado.ElementoSeleccionadoUI == 3)
        {
            edifSeleccionado(edif0, 0, 0, "Publicidad1");
        }
        else if (estado.ElementoSeleccionadoUI == 4)
        {
            edifSeleccionado(edifPapel, 1, 4, "Fabrica2");
        }
        else if (estado.ElementoSeleccionadoUI == 5)
        {
            edifSeleccionado(edifPlastico, 1, 4, "Fabrica3");
        }
        else if (estado.ElementoSeleccionadoUI == 6)
        {
            edifSeleccionado(edifVidrio, 1, 4, "Fabrica4");
        }
    }

    void edifSeleccionado(Transform trans, int offsetx, int offsetz, String edificioAColocar)
    {
        vRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(vRay, out vHit, 200))
        {
            Debug.DrawRay(vRay.origin, vRay.direction * 20, Color.red);            
            position_Click.x = vHit.collider.gameObject.transform.position.x;
            position_Click.z = vHit.collider.gameObject.transform.position.z;
            String lugar = vHit.collider.tag;
            Debug.Log(lugar);
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    //No hacer nada
                }
                else
                {
                    if (edificioAColocar.Equals("Fabrica1") && lugar.Equals("PisoTipo3"))
                    {
                        Instantiate(trans, new Vector3(position_Click.x + offsetx, 0, position_Click.z + offsetz), trans.rotation);
                        Fabrica nuevaFabrica = new Fabrica(position_Click.x + offsetx, position_Click.z + offsetz, "Organica");
                        for (int i = 0; i < nuevaFabrica.darCamionesFabrica().Length; i++)
                        {
                            Instantiate(camionBase, new Vector3(nuevaFabrica.PosicionX-1, 0, nuevaFabrica.PosicionZ-4), camionBase.transform.rotation);
                        }
                        unicaCiudad.añadirFabrica(nuevaFabrica);
                        estado.CantidadDinero -= 75;
                        estado.Expense -= 75;
                        OrdInit = 1;
                    }
                    else if (edificioAColocar.Equals("Fabrica2") && lugar.Equals("PisoTipo3"))
                    {
                        Instantiate(trans, new Vector3(position_Click.x + offsetx, 0, position_Click.z + offsetz), trans.rotation);
                        Fabrica nuevaFabrica = new Fabrica(position_Click.x + offsetx, position_Click.z + offsetz, "PapelYCarton");
                        if (estado.NivelEducacion>=5)
                        {
                            for (int i = 0; i < nuevaFabrica.darCamionesFabrica().Length; i++)
                            {
                                Instantiate(camionPapel, new Vector3(nuevaFabrica.PosicionX - 1, 0, nuevaFabrica.PosicionZ - 4), Quaternion.identity);
                            }
                        }
                        PapelInit = 1;
                        unicaCiudad.añadirFabrica(nuevaFabrica);
                        estado.CantidadDinero -= 100;
                        estado.Expense -= 100;
                    }
                    else if (edificioAColocar.Equals("Fabrica3") && lugar.Equals("PisoTipo3"))
                    {
                        Instantiate(trans, new Vector3(position_Click.x + offsetx, 0, position_Click.z + offsetz), trans.rotation);
                        Fabrica nuevaFabrica = new Fabrica(position_Click.x + offsetx, position_Click.z + offsetz, "PlasticoYAluminio");
                        if (estado.NivelEducacion >= 5)
                        {
                            for (int i = 0; i < nuevaFabrica.darCamionesFabrica().Length; i++)
                            {
                                Instantiate(camionPlastico, new Vector3(nuevaFabrica.PosicionX - 1, 0, nuevaFabrica.PosicionZ - 4), Quaternion.identity);
                            }
                        }
                        PlasticoInit = 1;
                        unicaCiudad.añadirFabrica(nuevaFabrica);
                        estado.CantidadDinero -= 100;
                        estado.Expense -= 100;
                    }
                    else if (edificioAColocar.Equals("Fabrica4") && lugar.Equals("PisoTipo3"))
                    {
                        Instantiate(trans, new Vector3(position_Click.x + offsetx, 0, position_Click.z + offsetz), trans.rotation);
                        Fabrica nuevaFabrica = new Fabrica(position_Click.x + offsetx, position_Click.z + offsetz, "Vidrio");
                        if (estado.NivelEducacion >= 5)
                        {
                            for (int i = 0; i < nuevaFabrica.darCamionesFabrica().Length; i++)
                            {
                                Instantiate(camionVidrio, new Vector3(nuevaFabrica.PosicionX - 1, 0, nuevaFabrica.PosicionZ - 4), Quaternion.identity);
                            }
                        }
                        VidrioInit = 1;
                        unicaCiudad.añadirFabrica(nuevaFabrica);
                        estado.CantidadDinero -= 100;
                        estado.Expense -= 100;
                    }
                    else if (edificioAColocar.Equals("Publicidad1") && lugar.Equals("PisoTipo1"))
                    {
                        Instantiate(trans, new Vector3(position_Click.x + offsetx, 0, position_Click.z + offsetz), trans.rotation);
                        botonPublicidad.interactable = true;
                        estado.CantidadDinero -= 125;
                        estado.Expense -= 125;
                        publicidad = 1;
                    }
                    else
                    {
                        estado.MensajeInformacion="Este edificio no se puede colocar aquí";
                        if (!estado.HayMensaje)
                        {
                            StartCoroutine(uiMessage.mostrarYBorrar());
                        }
                    }
                    estado.ElementoSeleccionadoUI = 0;
                }
                    

            }
        }
    }

    void inicializarCamiones()
    {
        ArrayList aInicializar = unicaCiudad.darFabricas();
        for (int i = 0; i < aInicializar.Count; i++)
        {
            Fabrica init = (Fabrica)aInicializar[i];
            if (init.TipoFabrica.Equals("PapelYCarton"))
            {
                
                for (int j = 0; j < init.darCamionesFabrica().Length; j++)
                {
                    Instantiate(camionPapel, new Vector3(init.PosicionX - 1, 0, init.PosicionZ - 4), Quaternion.identity);
                }
            }
            if (init.TipoFabrica.Equals("PlasticoYAluminio"))
            {

                for (int j = 0; j < init.darCamionesFabrica().Length; j++)
                {
                    Instantiate(camionPlastico, new Vector3(init.PosicionX - 1, 0, init.PosicionZ - 4), Quaternion.identity);
                }
            }
            if (init.TipoFabrica.Equals("Vidrio"))
            {

                for (int j = 0; j < init.darCamionesFabrica().Length; j++)
                {
                    Instantiate(camionVidrio, new Vector3(init.PosicionX - 1, 0, init.PosicionZ - 4), Quaternion.identity);
                }
            }
        }
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Casa");
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i].transform.GetChild(3).gameObject.SetActive(true);
            temp[i].transform.GetChild(1).gameObject.SetActive(true);
            temp[i].transform.GetChild(4).gameObject.SetActive(true);
        }
        initCamiones = true;
    }
}
