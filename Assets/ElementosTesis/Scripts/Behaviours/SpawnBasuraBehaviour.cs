using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasuraBehaviour : MonoBehaviour {

    public static float tiempoSpawnOrdinario;
    public static float tiempoSpawnPapel;
    public static float tiempoSpawnPlastico;
    public static float tiempoSpawnVidrio;
    public GameObject basura;
    public GameObject basuraOrdinaria;
    public GameObject basuraPapel;
    public GameObject basuraPlastico;
    public GameObject basuraVidrio;
    private float lastUpdate;
    private float lastUpdate1;
    private float lastUpdate2;
    private float lastUpdate3;
    private Casa estaCasa;
    private Ciudad unicaCiudad;

	// Update is called once per frame
    void Start()
    {
        unicaCiudad = Ciudad.InstanciaCiudad;
        estaCasa = unicaCiudad.buscarCasa(this.transform.position.x, this.transform.position.z);
        tiempoSpawnPapel = 13f;
        tiempoSpawnPlastico = 13f;
        tiempoSpawnVidrio = 13f;
        tiempoSpawnOrdinario = 6f;
    }
	void Update () {
        if (Time.time - lastUpdate >= tiempoSpawnOrdinario && !(estaCasa.estaLlena()))
        {
            estaCasa.generar();
            unicaCiudad.NumBasuraSinRecoger++;
            GameObject temp2 = Instantiate(basuraOrdinaria, new Vector3(this.transform.position.x - 1.731f, 2.421f, this.transform.position.z - 1.42f), Quaternion.identity);
            estaCasa.añadirBasura(new Basura(0,temp2));
            lastUpdate = Time.time;    
        }
        if (Time.time - lastUpdate1 >= tiempoSpawnPapel && !(estaCasa.estaLlenaPapel()) && gameObject.transform.GetChild(3).gameObject.activeInHierarchy ==true)
        {
            estaCasa.generarPapel();
            unicaCiudad.NumBasuraSinRecoger++;
            GameObject temp3 = Instantiate(basuraPapel, new Vector3(this.transform.position.x + 1f, 2.421f, this.transform.position.z - 1.5f), Quaternion.identity);
            estaCasa.añadirPapel(new Basura(1, temp3));
            lastUpdate1 = Time.time;
        }
        if (Time.time - lastUpdate3 >= tiempoSpawnVidrio && !(estaCasa.estaLlenaVidrio()) && gameObject.transform.GetChild(1).gameObject.activeInHierarchy == true)
        {
            estaCasa.generarVidrio();
            unicaCiudad.NumBasuraSinRecoger++;
            GameObject temp5 = Instantiate(basuraVidrio, new Vector3(this.transform.position.x, 2.421f, this.transform.position.z - 1.5f), Quaternion.identity);
            estaCasa.añadirVidrio(new Basura(2, temp5));
            lastUpdate3 = Time.time;
        }
        if (Time.time - lastUpdate2 >= tiempoSpawnPlastico && !(estaCasa.estaLlenaPlastico()) && gameObject.transform.GetChild(4).gameObject.activeInHierarchy == true)
        {
            estaCasa.generarPlastico();
            unicaCiudad.NumBasuraSinRecoger++;
            GameObject temp4 = Instantiate(basuraPlastico, new Vector3(this.transform.position.x + 1f, 2.421f, this.transform.position.z - 0.2f), Quaternion.identity);
            estaCasa.añadirPlastico(new Basura(3, temp4));
            lastUpdate2 = Time.time;
        }
        
    }
}
