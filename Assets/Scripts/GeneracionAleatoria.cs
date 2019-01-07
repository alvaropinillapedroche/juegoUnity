using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionAleatoria : MonoBehaviour {

    public GameObject plataformaVerde;
    public GameObject plataformaAzul;
    public GameObject plataformaBlanca;
    public GameObject plataformaRoja;
    public GameObject muellePlataformaVerde;
    public GameObject muellePlataformaAzul;
    public GameObject camaPlataformaVerde;
    public GameObject camaPlataformaAzul;
    public GameObject enemigoRojo;
    public GameObject enemigoAzul;
    public GameObject enemigoVerde;
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
        int num = Random.Range(2, 9); //Genero de 2 a 8 elementos
        Debug.Log(num);
        for (int i = 0; i < num; i++)
        {
            generarElementoAleatorio();
        }
        inicioTramo.position = new Vector3(0, inicioTramo.position.y + 11, 0);
    }

    private void generarElementoAleatorio()
    {
        int num = Random.Range(1, 101);
        Vector3 posAleatoria = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(inicioTramo.position.y, inicioTramo.position.y + 10), 0);
        if(num <= 40)
            Instantiate(plataformaVerde, posAleatoria, transform.rotation);
        else if (num>= 41 && num <= 60)
            Instantiate(plataformaAzul, posAleatoria, transform.rotation);
        else if (num >= 61 && num <= 71)
            Instantiate(plataformaBlanca, posAleatoria, transform.rotation);
        else
            Instantiate(plataformaRoja, posAleatoria, transform.rotation);
    }

    private void generarPlataformasObligatorias()
    {

        for(int i = 0; i < plataformasObligatorias.Length; i++)
        {
            int num = Random.Range(1, 11);
            Vector3 posAleatoria = new Vector3 (Random.Range(-4.5f, 4.5f), plataformasObligatorias[i].transform.position.y, 0);
            if (num <= 7) // 70%
                Instantiate(plataformaVerde, posAleatoria, transform.rotation).tag = "obligatoria";
            else if (num > 7 && num < 10) // 20%
                Instantiate(plataformaAzul, posAleatoria, transform.rotation).tag = "obligatoria";
            else // 10%
                Instantiate(plataformaBlanca, posAleatoria, transform.rotation).tag = "obligatoriaBlanca";
        }
    }
}
