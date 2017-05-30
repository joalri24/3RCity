using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoCamionBehaviour : MonoBehaviour {

    public static int STAND_BY = 0;
    public static int EN_RECORRIDO = 1;
    public static int DE_VUELTA = 2;
    public static int LLEGADA = 3;

    private Casa casaAVisitar;
    private Camion esteCamion;
    private Fabrica miFabrica;
    private EstadoJuego estado;
    private Ciudad uniqueCiudad;
  //  private Vector3 posIni;
    private NavMeshAgent agent;
    public int numBasuras;
    public int estadoRecogedor;
    private GameObject vertedero;


	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        estadoRecogedor = STAND_BY;
       // posIni = this.transform.position;
        uniqueCiudad = Ciudad.InstanciaCiudad;
        estado = EstadoJuego.InstanciaEstadoJuego;
        miFabrica = uniqueCiudad.buscarFabrica(this.transform.position.x + 1, this.transform.position.z + 4);
        esteCamion = new Camion(miFabrica);
        miFabrica.añadirCamion(esteCamion);
        casaAVisitar = null;
        vertedero = GameObject.FindGameObjectWithTag("GarbagePlace");
    }
	
	// Update is called once per frame
	void Update ()
    {
        ArrayList casasAvisitar = uniqueCiudad.darCasas();
        if (casasAvisitar.Count!=0&&esteCamion.EstaEnCamino==false)
        {
            casaAVisitar = (Casa)casasAvisitar[Random.Range(0, casasAvisitar.Count)];
        }

        if (estadoRecogedor==STAND_BY && !esteCamion.estaFull() && casaAVisitar!=null)
        {
            if (!casaAVisitar.noHayBasura())
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
        else if (estadoRecogedor==EN_RECORRIDO)
        {
            
            if(Vector3.Distance(agent.destination, this.transform.position) <= 3f)
            {
                esteCamion.recoger(casaAVisitar);
                for (int i = 0; i < esteCamion.LoRecogido ; i++)
                {
                    Destroy(casaAVisitar.darBasuraAcumulada()[i].darGameobject());
                    casaAVisitar.darBasuraAcumulada()[i] = null;
                     uniqueCiudad.NumBasuraSinRecoger--;
                }
                casaAVisitar.darBasuraAcumulada().RemoveAll((o) => o == null);
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
            agent.destination = vertedero.transform.position;
            estadoRecogedor = LLEGADA;
        }
        else if (Vector3.Distance(transform.position, vertedero.transform.position) <=6f &&estadoRecogedor==LLEGADA)
        {
            estadoRecogedor = STAND_BY;
            miFabrica.CantidadRecogida += esteCamion.Llenado;
            uniqueCiudad.NumBasuraRecogida += esteCamion.Llenado;
            estado.Income += esteCamion.Llenado*2;
            estado.CantidadDinero += esteCamion.Llenado*2;
            esteCamion.Llenado = 0;
            
        }
        
    }
}
