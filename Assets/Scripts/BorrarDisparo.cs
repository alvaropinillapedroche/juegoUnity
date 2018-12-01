using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrarDisparo : MonoBehaviour {
   
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("disparo"))
        {
            Destroy(other.gameObject);
        }
    }
}
