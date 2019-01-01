using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausaBoton : MonoBehaviour {

    public Text textoPausaBoton;
    public SpriteRenderer fondo;
    public Text textoBotonPausa;
    public Canvas confirmacion;
    private bool pausado;

    private void Start()
    {
        pausado = false;
    }

    void Update ()
    {
        if (!pausado && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            confirmacion.enabled = true;
        }
    }

    public void pausaReanudar()
    {
        if (!pausado)
        {
            Time.timeScale = 0;
            fondo.sortingOrder = 3;
            textoPausaBoton.enabled = true;
            textoBotonPausa.text = "▶";
            pausado = true;
        }
        else
        {
            Time.timeScale = 1;
            fondo.sortingOrder = 0;
            textoPausaBoton.enabled = false;
            textoBotonPausa.text = "| |";
            pausado = false;
        }
        
    }
}
