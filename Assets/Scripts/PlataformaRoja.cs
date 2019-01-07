using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaRoja : MonoBehaviour {

    public Transform objetivo;
    private bool tocada;
    private float velocidad;
    private Animator anim;
    private AudioSource sonido;

    void Start () {
        tocada = false;
        velocidad = 7;
        anim = GetComponent<Animator>();
        sonido = GetComponent<AudioSource>();
    }
	
	void Update () {
        anim.SetBool("tocada", tocada);
        if(tocada)
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D c){
        if (c.gameObject.tag == "Player" && c.relativeVelocity.y <= 0){
            tocada = true;
            sonido.Play();
        }    
    }

    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
}
