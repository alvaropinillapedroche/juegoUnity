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
    public Transform inicioTramo2;
    public GameObject[] plataformasObligatorias;
    public GameObject[] plataformasObligatorias2;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(generarSiguienteTramo());
            StartCoroutine(generarSiguienteTramo2());
            transform.position = new Vector3(0, transform.position.y + 22, 0);
        }
    }

    private IEnumerator generarSiguienteTramo()
    {
        generarPlataformasObligatorias();
        int num = Random.Range(2, 9); //Genero de 2 a 8 elementos
        GameObject elemento;
        for (int i = 0; i < num; i++)
        {
            elemento = generarElementoAleatorio(true);
            yield return new WaitForSeconds(0.10f);
            if (elemento != null)
                elemento.tag = cambiarTag(elemento.tag);
        }
        inicioTramo.position = new Vector3(0, inicioTramo.position.y + 22, 0);
    }

    private IEnumerator generarSiguienteTramo2()
    {
        generarPlataformasObligatorias2();
        int num = Random.Range(2, 11); //Genero de 2 a 10 elementos
        GameObject elemento;
        for (int i = 0; i < num; i++)
        {
            elemento = generarElementoAleatorio(false);
            yield return new WaitForSeconds(0.15f);
            if (elemento != null)
                elemento.tag = cambiarTag(elemento.tag);
        }
        inicioTramo2.position = new Vector3(0, inicioTramo2.position.y + 22, 0);
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

    private GameObject generarElementoAleatorio(bool tramo1)
    {
        int roja = Random.Range(0,2); // 50% generacion roja y 50% un elemento cualquiera
        Vector3 posAleatoria;
        GameObject elemento;
        if (tramo1)
            posAleatoria = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(inicioTramo.position.y, inicioTramo.position.y + 10), 0);
        else
            posAleatoria = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(inicioTramo2.position.y, inicioTramo2.position.y + 10), 0);

        if (roja == 1)
            elemento = Instantiate(plataformaRoja, posAleatoria, transform.rotation);
        else
        {
            int num = Random.Range(1, 101);
            if (num <= 45)
                elemento = Instantiate(plataformaVerde, posAleatoria, transform.rotation);
            else if (num >= 46 && num <= 55)
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
        }

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

    private void generarPlataformasObligatorias2()
    {

        for (int i = 0; i < plataformasObligatorias2.Length; i++)
        {
            int num = Random.Range(1, 11);
            Vector3 posAleatoria = new Vector3(Random.Range(-4.5f, 4.5f), plataformasObligatorias2[i].transform.position.y, 0);
            if (num <= 7) // 70%
                Instantiate(plataformaVerde, posAleatoria, transform.rotation).tag = "obligatoria";
            else if (num > 7 && num < 10) // 20%
                Instantiate(plataformaAzul, posAleatoria, transform.rotation).tag = "obligatoria";
            else // 10%
                Instantiate(plataformaBlanca, posAleatoria, transform.rotation).tag = "obligatoriaBlanca";
        }
    }
}
