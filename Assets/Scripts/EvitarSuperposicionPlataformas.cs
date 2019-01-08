using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvitarSuperposicionPlataformas : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("obligatoria")
            && !other.gameObject.CompareTag("obligatoriaBlanca")
            && !other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
        }
    }

    void OnBecameVisible()
    {
        Destroy(this.GetComponent<Rigidbody2D>());
    }

}
