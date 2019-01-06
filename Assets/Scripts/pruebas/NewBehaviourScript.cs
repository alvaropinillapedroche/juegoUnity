using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, 0);
    }
}
