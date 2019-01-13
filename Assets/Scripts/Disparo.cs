using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {
    public float velocidad;
    public Rigidbody2D bola;

    void OnEnable(){
        bola.velocity = transform.up * velocidad;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo") || collision.gameObject.CompareTag("obligatorioEnemigo"))
        {
            Destroy(this.gameObject);
        }
    }

}
