using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparos : MonoBehaviour {
    public float ratio;
    private float disparoSiguiente;
    public GameObject disparo;
    public Transform disparos;
    private AudioSource sonido;

    // Use this for initialization
    void Start () {
        disparoSiguiente = 0;
        sonido = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update() {

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && Time.time > disparoSiguiente)
        {
            disparoSiguiente = Time.time + ratio;
            Instantiate(disparo, disparos.position, disparos.rotation);
            sonido.Play();
        }
    }
}
