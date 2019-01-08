using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puntuaciones : MonoBehaviour {

    public Canvas canvasPuntuaciones;
    private bool cargarInfinito;

    void Awake()
    {
        if (PlayerPrefs.GetString("infinito", "true").Equals("true"))
            cargarInfinito = true;
        else
            cargarInfinito = false;
        int posicionMarcar = PlayerPrefs.GetInt("marcarPosicion", -1);
        int posicionMarcar2 = PlayerPrefs.GetInt("marcarPosicion2", -1);
        int marca = Math.Max(posicionMarcar, posicionMarcar2);
        string[] nombres = new string[10];
        int[] puntuaciones = new int[10];
        Text[] textos = canvasPuntuaciones.GetComponentsInChildren<Text>();

        if (posicionMarcar > -1 || cargarInfinito == false)
        {
            Array.Copy(obtenerArrayNombres(false), nombres, 10);
            Array.Copy(obtenerArrayPuntuaciones(false), puntuaciones, 10);
            textos[textos.Length - 1].text = "MODO FINITO";
        }
        else //infinito
        {
            Array.Copy(obtenerArrayNombres(true), nombres, 10);
            Array.Copy(obtenerArrayPuntuaciones(true), puntuaciones, 10);
            textos[textos.Length - 1].text = "MODO INFINITO";
        }

        for (int i = 0; i < 10; i++)
        { //puntuaciones
            textos[i].text = puntuaciones[i].ToString();
        }
        for (int i = 0; i < 10; i++)
        { //nombres
            textos[i + 10].text = nombres[i];
        }

        if (marca > -1){
            textos[marca].fontStyle = FontStyle.Bold;
            textos[marca].color = Color.blue;
            textos[marca + 10].fontStyle = FontStyle.Bold;
            textos[marca + 10].color = Color.blue;
            textos[marca + 20].fontStyle = FontStyle.Bold;
            textos[marca + 20].color = Color.blue;
        }

        PlayerPrefs.SetInt("marcarPosicion", -1);
        PlayerPrefs.SetInt("marcarPosicion2", -1);
    }

    private int[] obtenerArrayPuntuaciones(bool infinito)
    {
        string punt;
        if(infinito)
            punt = PlayerPrefs.GetString("puntuaciones2", "0,0,0,0,0,0,0,0,0,0");
        else
            punt = PlayerPrefs.GetString("puntuaciones", "0,0,0,0,0,0,0,0,0,0");
        string[] puntuacionesString = punt.Split(',');
        int[] puntuaciones = new int[10];
        for (int i = 0; i < puntuaciones.Length; i++)
            puntuaciones[i] = int.Parse(puntuacionesString[i]);

        return puntuaciones;
    }

    private string[] obtenerArrayNombres(bool infinito)
    {
        string punt;
        if(infinito)
            punt = PlayerPrefs.GetString("nombres2", "x,x,x,x,x,x,x,x,x,x");
        else
            punt = PlayerPrefs.GetString("nombres", "x,x,x,x,x,x,x,x,x,x");
        string[] nombres = punt.Split(',');
        return nombres;
    }

    public void cambiarModo()
    {
        if (cargarInfinito)
            PlayerPrefs.SetString("infinito", "false");
        else
            PlayerPrefs.SetString("infinito", "true");

        SceneManager.LoadScene("Puntuaciones");
    }

    public void volverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
