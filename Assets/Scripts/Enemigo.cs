using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    private AudioSource sonido;

    private void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("disparo"))
        {
            sonido.Play();
            Destroy(this.gameObject, 0.1f);
        }
    }

}
