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
            StartCoroutine(generarSiguienteTramo());
            transform.position = new Vector3(0, transform.position.y + 11, 0);
        }
    }

    private IEnumerator generarSiguienteTramo()
    {
        generarPlataformasObligatorias();
        int num = Random.Range(0, 9); //Genero de 0 a 8 elementos
        GameObject elemento;
        Debug.Log(num);
        for (int i = 0; i < 8; i++)
        {
            elemento = generarElementoAleatorio();
            yield return new WaitForSeconds(0.1f);
            if (elemento != null)
                elemento.tag = cambiarTag(elemento.tag);
        }
        inicioTramo.position = new Vector3(0, inicioTramo.position.y + 11, 0);
    }

    private string cambiarTag(string tag)
    {
        string newTag;

        if (tag.Equals("plataformaBlanca"))
            newTag = "obligatoriaBlanca";
        else if (tag.Equals("enemigo"))
            newTag = "obligatorioEnemigo";
        else if (tag.Equals("plataformaRoja"))
            newTag = "obligatoriaRoja";
        else
            newTag = "obligatoria";

        return newTag;
    }

    private GameObject generarElementoAleatorio()
    {
        int num = Random.Range(1, 101);
        Vector3 posAleatoria = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(inicioTramo.position.y, inicioTramo.position.y + 10), 0);
        GameObject elemento;
        if(num <= 45)
            elemento = Instantiate(plataformaVerde, posAleatoria, transform.rotation);
        else if (num>= 46 && num <= 55)
            elemento = Instantiate(plataformaAzul, posAleatoria, transform.rotation);
        else if (num >= 56 && num <= 65)
            elemento = Instantiate(plataformaRoja, posAleatoria, transform.rotation);
        else if (num >= 66 && num <= 71)
            elemento = Instantiate(plataformaBlanca, posAleatoria, transform.rotation);
        else if (num >= 72 && num <= 81)
            elemento = Instantiate(muellePlataformaVerde, posAleatoria, transform.rotation);
        else if (num >= 82 && num <= 86)
            elemento = Instantiate(muellePlataformaAzul, posAleatoria, transform.rotation);
        else if (num >= 87 && num <= 90)
            elemento = Instantiate(camaPlataformaVerde, posAleatoria, transform.rotation);
        else if (num >= 91 && num <= 94)
            elemento = Instantiate(camaPlataformaAzul, posAleatoria, transform.rotation);
        else if (num >= 95 && num <= 97)
            elemento = Instantiate(enemigoRojo, posAleatoria, transform.rotation);
        else if (num >= 98 && num <= 99)
            elemento = Instantiate(enemigoAzul, posAleatoria, transform.rotation);
        else
            elemento = Instantiate(enemigoVerde, posAleatoria, transform.rotation);

        return elemento;
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
