using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionesBotones : MonoBehaviour {

    public void jugar()
    {
        SceneManager.LoadScene("escena");
    }

    public void puntuaciones()
    {
        SceneManager.LoadScene("Puntuaciones");
    }

    public void salir()
    {
        Application.Quit();
    }

    public void menuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
}
