using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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
    public Canvas disparo;
    public Canvas botonesFin;
    public GameObject controlPausa;
    public Canvas pregunta;
    public Canvas canvasGuardarPuntuacion;
    public InputField fieldNombre;
    private int posicion;

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
            textoFin.text = "GAME OVER\n\n"+marcador.text;
            textoFin.enabled = true;
            sonido.Play();
            fin();
        }
        else if (int.Parse(marcador.text) >= puntFinNivel && doodler.position.y <= maxAltura){ //fin partida, no hay más nivel
            estado = Estados.ended;
            marcador.enabled = false;
            textoFinNivel.text = "¡ENHORABUENA!\nHas llegado al final\n\n" + puntFinNivel;
            textoFinNivel.enabled = true;
            sonido.PlayOneShot(finNivel);
            fin();
        }   
    }

    private void fin()
    {
        pausa.enabled = false;
        controlDerecha.enabled = false;
        controlIzquierda.enabled = false;
        disparo.enabled = false;
        controlPausa.SetActive(false);
        posicion = posPuntuacionAlta();
        if (posicion > -1)
            pregunta.enabled = true;
        else
            botonesFin.enabled = true;
    }

    private int posPuntuacionAlta()
    {
        int[] puntuaciones = new int[10];
        Array.Copy(obtenerArrayPuntuaciones(), puntuaciones, 10);
        int puntuacion = int.Parse(marcador.text);

        for (int i = 0; i < puntuaciones.Length; i++)
        {
            if (puntuacion > puntuaciones[i])
                return i;
        }
        return -1;
    }

    public void siGuarda()
    {
        pregunta.enabled = false;
        canvasGuardarPuntuacion.enabled = true;
    }

    public void noGuarda()
    {
        pregunta.enabled = false;
        botonesFin.enabled = true;
    }

    private int[] obtenerArrayPuntuaciones()
    {
        string punt = PlayerPrefs.GetString("puntuaciones", "0,0,0,0,0,0,0,0,0,0");
        string[] puntuacionesString = punt.Split(',');
        int[] puntuaciones = new int[10];
        for (int i = 0; i < puntuaciones.Length; i++)
            puntuaciones[i] = int.Parse(puntuacionesString[i]);

        return puntuaciones;
    }

    private string[] obtenerArrayNombres()
    {
        string punt = PlayerPrefs.GetString("nombres", "x,x,x,x,x,x,x,x,x,x");
        string[] nombres = punt.Split(',');
        return nombres;
    }

    public void guardarPuntuacion()
    {
        string nombre = fieldNombre.text;
        if (nombre.Trim() == ""){
            fieldNombre.text = "";
            fieldNombre.placeholder.color = Color.red;
        }
        else if (nombre.Contains(",")){
            fieldNombre.text = "";
            fieldNombre.placeholder.color = Color.red;
            fieldNombre.placeholder.GetComponent<Text>().text = "Nombre sin comas";
        }
        else{ //todo correcto
            nombre = nombre.Trim();
            int puntuacion = int.Parse(marcador.text);
            string[] nombres = new string[10];
            Array.Copy(obtenerArrayNombres(), nombres, 10);
            int[] puntuaciones = new int[10];
            Array.Copy(obtenerArrayPuntuaciones(), puntuaciones, 10);

            if(posicion == puntuaciones.Length - 1){
                puntuaciones[posicion] = puntuacion;
                nombres[posicion] = nombre;
            }
            else{
                Array.Copy(puntuaciones, posicion, puntuaciones, posicion + 1, puntuaciones.Length - posicion - 1);
                Array.Copy(nombres, posicion, nombres, posicion + 1, nombres.Length - posicion - 1);
                puntuaciones[posicion] = puntuacion;
                nombres[posicion] = nombre;
            }

            PlayerPrefs.SetString("puntuaciones", crearStringPuntuaciones(puntuaciones));
            PlayerPrefs.SetString("nombres", crearStringNombres(nombres));
            PlayerPrefs.SetInt("marcarPosicion", posicion);
            SceneManager.LoadScene("Puntuaciones");
        }
    }

    private string crearStringPuntuaciones(int[] puntuaciones)
    {
        string puntuacionesString = puntuaciones[0].ToString();

        for (int i = 1; i < puntuaciones.Length; i++){
            puntuacionesString += "," + puntuaciones[i];
        }

        return puntuacionesString;
    }

    private string crearStringNombres(string[] nombres)
    {
        string nombresString = nombres[0];

        for (int i = 1; i < nombres.Length; i++){
            nombresString += "," + nombres[i];
        }

        return nombresString;
    }
}
