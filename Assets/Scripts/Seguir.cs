using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Seguir : MonoBehaviour {

    public Transform doodler;
    public Text marcador;
    private float maxAltura;
    private int puntFinNivel;
    private enum Estados { stop, playing, ended };
    private Estados estado;
    public Text textoPausa;
    public Text textoFin;
    public Text textoFinNivel;
    public SpriteRenderer fondo;
    private AudioSource sonido;
    public AudioClip finNivel;
    public Canvas pausa;
    public Canvas controlDerecha;
    public Canvas controlIzquierda;
    //public Canvas botonesFin;

    void Start () {
        puntFinNivel = 2900;
        maxAltura = 0;
        estado = Estados.playing;
        sonido = GetComponent<AudioSource>();
    }

	void Update () {
        if (estado == Estados.playing && Input.GetKeyDown(KeyCode.P)){
            estado = Estados.stop;
            Time.timeScale = 0;
            fondo.sortingOrder = 3;
            textoPausa.enabled = true;
        }
        else if (estado == Estados.stop && Input.GetKeyDown(KeyCode.P)){
            estado = Estados.playing;
            Time.timeScale = 1;
            fondo.sortingOrder = 0;
            textoPausa.enabled = false;
        }
        else if (estado == Estados.ended && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("escena");
        }

        if (doodler.position.y > maxAltura && estado == Estados.playing){
            maxAltura = doodler.position.y;
            transform.position = new Vector3(0, maxAltura, -10f);
            marcador.text = Mathf.Floor(maxAltura * 10).ToString();
        }
        else if (doodler.position.y <= maxAltura - 5 && doodler.position.y > -7){ //Pierde
            estado = Estados.ended;
            doodler.position = new Vector3(doodler.position.x, -7, 0);
            transform.position = new Vector3(0, -13, -10);
            marcador.enabled = false;
            textoFin.text = "GAME OVER\n\n"+marcador.text+"\n\nPulsa R para volver a jugar";
            textoFin.enabled = true;
            sonido.Play();
            pausa.enabled = false;
            controlDerecha.enabled = false;
            controlIzquierda.enabled = false;
            //botonesFin.enabled = true;
        }
        else if (int.Parse(marcador.text) >= puntFinNivel && doodler.position.y <= maxAltura){ //fin partida, no hay más nivel
            estado = Estados.ended;
            marcador.enabled = false;
            textoFinNivel.text = "¡ENHORABUENA!\nHas llegado al final\n\n" + marcador.text + "\n\nPulsa R para volver a jugar";
            textoFinNivel.enabled = true;
            sonido.PlayOneShot(finNivel);
        }
    }
}
