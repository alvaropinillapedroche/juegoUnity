using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puntuaciones : MonoBehaviour {

    public Canvas canvasPuntuaciones;

    void Awake()
    {
        int posicionMarcar = PlayerPrefs.GetInt("marcarPosicion", -1);
        string[] nombres = new string[10];
        Array.Copy(obtenerArrayNombres(), nombres, 10);
        int[] puntuaciones = new int[10];
        Array.Copy(obtenerArrayPuntuaciones(), puntuaciones, 10);
        Text[] textos = canvasPuntuaciones.GetComponentsInChildren<Text>();

        for (int i = 0; i < 10; i++){ //puntuaciones
            textos[i].text = puntuaciones[i].ToString();
        }
        for (int i = 0; i < 10; i++){ //nombres
            textos[i + 10].text = nombres[i];
        }

        if (posicionMarcar > -1){
            textos[posicionMarcar].fontStyle = FontStyle.Bold;
            textos[posicionMarcar].color = Color.blue;
            textos[posicionMarcar + 10].fontStyle = FontStyle.Bold;
            textos[posicionMarcar + 10].color = Color.blue;
            textos[posicionMarcar + 20].fontStyle = FontStyle.Bold;
            textos[posicionMarcar + 20].color = Color.blue;
        }

        PlayerPrefs.SetInt("marcarPosicion", -1);
    }

    private int[] obtenerArrayPuntuaciones()
    {
        string punt = PlayerPrefs.GetString("puntuaciones", "0,0,0,0,0,0,0,0,0,0");
        string[] puntuacionesString = punt.Split(',');
        int[] puntuaciones = new int[10];
        for (int i = 0; i < puntuaciones.Length; i++)
            puntuaciones[i] = int.Parse(puntuacionesString[i]);

        return puntuaciones;
    }

    private string[] obtenerArrayNombres()
    {
        string punt = PlayerPrefs.GetString("nombres", "x,x,x,x,x,x,x,x,x,x");
        string[] nombres = punt.Split(',');
        return nombres;
    }

    public void volverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
