using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoCamionPapelBehaviour : MonoBehaviour {

    public static int STAND_BY = 0;
    public static int EN_RECORRIDO = 1;
    public static int DE_VUELTA = 2;
    public static int LLEGADA = 3;

    private Casa casaAVisitar;
    private Camion esteCamion;
    private Fabrica miFabrica;
    private Ciudad uniqueCiudad;
    private EstadoJuego estado;
    private Vector3 posIni;
    private NavMeshAgent agent;
    public int estadoRecogedor;
    private GameObject basuraRecoger;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        estadoRecogedor = STAND_BY;
        posIni = this.transform.position;
        uniqueCiudad = Ciudad.InstanciaCiudad;
        estado = EstadoJuego.InstanciaEstadoJuego;
        miFabrica = uniqueCiudad.buscarFabrica(this.transform.position.x + 1, this.transform.position.z + 4);
        esteCamion = new Camion(miFabrica);
        miFabrica.añadirCamion(esteCamion);
        casaAVisitar = null;
    }

    // Update is called once per frame
    void Update()
    {
        ArrayList casasAvisitar = uniqueCiudad.darCasas();
        if (casasAvisitar.Count != 0 && esteCamion.EstaEnCamino == false)
        {
            casaAVisitar = (Casa)casasAvisitar[Random.Range(0, casasAvisitar.Count)];
        }

        if (estadoRecogedor == STAND_BY && !esteCamion.estaFull() && casaAVisitar != null)
        {
            if (!casaAVisitar.noHayPapel())
            {
                if (casaAVisitar.EnVisita == false)
                {
                    casaAVisitar.EnVisita = true;
                    agent.destination = new Vector3(casaAVisitar.PosicionEnX, 0, casaAVisitar.PosicionEnZ);
                    estadoRecogedor = EN_RECORRIDO;
                    esteCamion.EstaEnCamino = true;
                }
            }


        }
        else if (estadoRecogedor == EN_RECORRIDO)
        {

            if (Vector3.Distance(agent.destination, this.transform.position) <= 3f)
            {
                esteCamion.recogerPapel(casaAVisitar);
                for (int i = 0; i < esteCamion.LoRecogidoPapel; i++)
                {
                        Destroy(casaAVisitar.darPapelAcumulado()[i].darGameobject());
                        casaAVisitar.darPapelAcumulado()[i] = null;
                        uniqueCiudad.NumBasuraSinRecoger--;    
                }
                casaAVisitar.darPapelAcumulado().RemoveAll((o) => o == null);
                casaAVisitar.EnVisita = false;
                esteCamion.EstaEnCamino = false;
                estadoRecogedor = STAND_BY;
            }
        }
        else if (estadoRecogedor == STAND_BY && esteCamion.estaFull())
        {
            estadoRecogedor = DE_VUELTA;
        }
        else if (estadoRecogedor == DE_VUELTA)
        {
            agent.destination = posIni;
            estadoRecogedor = LLEGADA;
        }
        else if (Vector3.Distance(transform.position, posIni) <= 6f && estadoRecogedor == LLEGADA)
        {
            int ganado = (int)(esteCamion.Llenado * 2.05f);
            estadoRecogedor = STAND_BY;
            miFabrica.CantidadRecogida += esteCamion.Llenado;
            uniqueCiudad.NumPapelReciclado += esteCamion.Llenado;
            estado.Income += ganado;
            estado.CantidadDinero += ganado;
            esteCamion.Llenado = 0;
        }
    }
}
