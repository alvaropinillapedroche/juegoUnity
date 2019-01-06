using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionAleatoria : MonoBehaviour {

    public GameObject plataformaVerde;
    public GameObject plataformaAzul;
    public GameObject plataformaBlanca;
    public Transform inicioTramo;
    public GameObject[] plataformasObligatorias;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            generarSiguienteTramo();
            transform.position = new Vector3(0, transform.position.y + 11, 0);
        }
    }

    private void generarSiguienteTramo()
    {
        generarPlataformasObligatorias();
        for (int i = 0; i < 10; i++)
        {
            Vector3 posAleatoria = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(inicioTramo.position.y, inicioTramo.position.y + 10), 0);
            GameObject plataforma = Instantiate(plataformaVerde, posAleatoria, transform.rotation);
        }
        inicioTramo.position = new Vector3(0, inicioTramo.position.y + 11, 0);
    }

    private void generarPlataformasObligatorias()
    {

        for(int i = 0; i < plataformasObligatorias.Length; i++)
        {
            //int num = Random.Range(1, 11);
            Vector3 posAleatoria = new Vector3 (Random.Range(-4.5f, 4.5f), plataformasObligatorias[i].transform.position.y, 0);
            //if(num <= 7) // 70%
                GameObject plataforma = Instantiate(plataformaVerde, posAleatoria, transform.rotation);
                plataforma.tag = "obligatoria";
            /*else if (num > 7 && num < 10) // 20%
                /Instantiate(plataformaAzul, posAleatoria, transform.rotation);
            else // 10%
                Instantiate(plataformaBlanca, posAleatoria, transform.rotation);*/
            
        }
    }
}
