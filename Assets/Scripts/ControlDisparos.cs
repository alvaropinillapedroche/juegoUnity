using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparos : MonoBehaviour {
    public float ratio;
    private float disparoSiguiente;
    public GameObject disparo;
    public Transform disparos;
    private AudioSource sonido;

    void Start () {
        disparoSiguiente = 0;
        sonido = GetComponent<AudioSource>();
    }

    public void disparar()
    {
        if (Time.time > disparoSiguiente)
        {
            disparoSiguiente = Time.time + ratio;
            Instantiate(disparo, disparos.position, disparos.rotation);
            sonido.Play();
        }
    }
}
