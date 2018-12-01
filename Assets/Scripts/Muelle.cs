using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muelle : MonoBehaviour{

    private bool usado;
    private Animator anim;
    void Start(){
        usado = false;
        anim = GetComponent<Animator>();
    }
    void Update(){
        anim.SetBool("usado", usado);
    }

    void OnCollisionEnter2D(Collision2D c){
        if (c.relativeVelocity.y <= 0)
            usado = true;
    }
}
