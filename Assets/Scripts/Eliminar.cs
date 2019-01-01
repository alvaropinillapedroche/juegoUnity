using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliminar : MonoBehaviour {

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
