using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonesFinPartida : MonoBehaviour {

	public void reintentar()
    {
        SceneManager.LoadScene("escena");
    }

    public void irMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void salir()
    {
        Application.Quit();
    }
}
