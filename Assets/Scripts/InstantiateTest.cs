using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTest : MonoBehaviour {

    public GameObject camion;
	// Use this for initialization
	void Start () {
        Instantiate(camion, transform.position, camion.transform.rotation);
	}

}
