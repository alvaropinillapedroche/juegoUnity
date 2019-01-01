using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlVolverMenu : MonoBehaviour {

    public Canvas confirmacion;

    public void si()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void no()
    {
        confirmacion.enabled = false;
        Time.timeScale = 1;
    }
}
