using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    private AudioSource sonido;

    private void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, -6, 0);
        }
       
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
