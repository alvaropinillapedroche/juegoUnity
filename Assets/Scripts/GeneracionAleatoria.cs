using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionAleatoria : MonoBehaviour {

    public GameObject plataformaVerde;
    public Transform inicioTramo;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(0, transform.position.y + 11, 0);
            generarSiguienteTramo();
        }
    }

    private void generarSiguienteTramo()
    {
        for (int i = 0; i < 12; i++)
        {
            Vector3 posAleatoria = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(inicioTramo.position.y, inicioTramo.position.y + 10), 0);
            Instantiate(plataformaVerde, posAleatoria, transform.rotation);
        }
        inicioTramo.position = new Vector3(0, inicioTramo.position.y + 11, 0);
    }
}
