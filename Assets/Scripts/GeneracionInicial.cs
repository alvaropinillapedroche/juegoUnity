using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionInicial : MonoBehaviour {

    public GameObject[] posiciones;
    public GameObject plataformaVerde;

	void Start () {
        for (int i = 0; i < posiciones.Length; i++)
        {
            Vector3 posAleatoria = new Vector3(Random.Range(-4.5f, 4.5f), posiciones[i].transform.position.y, 0);
            Instantiate(plataformaVerde, posAleatoria, transform.rotation);
        }
        
    }

}
