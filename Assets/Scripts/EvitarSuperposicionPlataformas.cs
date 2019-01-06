using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvitarSuperposicionPlataformas : MonoBehaviour {

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
            Destroy(collision.gameObject);
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("plataforma"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnBecameVisible()
    {
        Destroy(this.GetComponent<Rigidbody2D>());
    }

}
