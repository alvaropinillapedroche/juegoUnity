using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimientoFlechas : MonoBehaviour {

    public GameObject doodler;

    private SpriteRenderer render;
    private float velocidad;
    private bool derecha;
    private bool izquierda;

    void Start () {
        velocidad = 8;
        derecha = false;
        izquierda = false;
        render = doodler.GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate () {
        if(derecha)
            doodler.transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        else if (izquierda)
            doodler.transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }

    public void irDerecha()
    {
        derecha = true;
        render.flipX = false;
    }

    public void finDerecha()
    {
        derecha = false;
    }

    public void irIzquierda()
    {
        izquierda = true;
        render.flipX = true;
    }

    public void finIzquierda()
    {
        izquierda = false;
    }
}
