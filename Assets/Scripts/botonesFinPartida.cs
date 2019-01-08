using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonesFinPartida : MonoBehaviour {

	public void reintentar()
    {
        if(SceneManager.GetActiveScene().name == "escena")
            SceneManager.LoadScene("escena");
        else
            SceneManager.LoadScene("modo infinito");
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
