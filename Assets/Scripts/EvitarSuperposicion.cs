using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvitarSuperposicion : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("obligatoria")
            && !other.gameObject.CompareTag("obligatoriaBlanca")
            && !other.gameObject.CompareTag("obligatoriaRoja")
            && !other.gameObject.CompareTag("Player")
            && !other.gameObject.CompareTag("obligatorioEnemigo")
            && !other.gameObject.CompareTag("muelle")
            && !other.gameObject.CompareTag("cama"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnBecameVisible()
    {
        Destroy(this.GetComponent<Rigidbody2D>());
        Collider2D[] colliders = this.GetComponents<Collider2D>();
        colliders[0].enabled = false;
        if (colliders.Length > 2)
            colliders[1].enabled = false;
    }
}
