using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Seguir : MonoBehaviour {

    public Transform doodler;
    public Text marcador;
    private float maxAltura;
    private int puntFinNivel;
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
    private int puntuacion;
    private bool modoInfinito;
    private bool final;

    void Start () {
        puntFinNivel = 2900;
        maxAltura = 0;
        sonido = GetComponent<AudioSource>();
        final = false;
        if (SceneManager.GetActiveScene().name == "modo infinito")
            modoInfinito = true;
        else
            modoInfinito = false;
    }

	void Update () {
        if (doodler.position.y > maxAltura && !final){
            maxAltura = doodler.position.y;
            transform.position = new Vector3(0, maxAltura, -10f);
            marcador.text = Mathf.Floor(maxAltura * 10).ToString();
        }
        else if (doodler.position.y <= maxAltura - 5 && doodler.position.y > -7){ //Pierde
            doodler.position = new Vector3(doodler.position.x, -7, 0);
            transform.position = new Vector3(0, -13, -10);
            marcador.enabled = false;
            textoFin.text = "GAME OVER\n\n"+marcador.text;
            textoFin.enabled = true;
            sonido.Play();
            puntuacion = int.Parse(marcador.text);
            fin();
        }
        else if (int.Parse(marcador.text) >= puntFinNivel && doodler.position.y <= maxAltura
                 && !final && !modoInfinito){ //fin partida, no hay más nivel
            final = true;
            marcador.enabled = false;
            textoFinNivel.text = "¡ENHORABUENA!\nHas llegado al final\n\n" + puntFinNivel;
            textoFinNivel.enabled = true;
            sonido.PlayOneShot(finNivel);
            puntuacion = puntFinNivel;
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
        if(modoInfinito)
            Array.Copy(obtenerArrayPuntuaciones(true), puntuaciones, 10);
        else
            Array.Copy(obtenerArrayPuntuaciones(false), puntuaciones, 10);

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

    private int[] obtenerArrayPuntuaciones(bool infinito)
    {
        string punt;
        if(infinito)
            punt = PlayerPrefs.GetString("puntuaciones2", "0,0,0,0,0,0,0,0,0,0");
        else
            punt = PlayerPrefs.GetString("puntuaciones", "0,0,0,0,0,0,0,0,0,0");
        string[] puntuacionesString = punt.Split(',');
        int[] puntuaciones = new int[10];
        for (int i = 0; i < puntuaciones.Length; i++)
            puntuaciones[i] = int.Parse(puntuacionesString[i]);

        return puntuaciones;
    }

    private string[] obtenerArrayNombres(bool infinito)
    {
        string punt;
        if(infinito)
            punt = PlayerPrefs.GetString("nombres2", "x,x,x,x,x,x,x,x,x,x");
        else
            punt = PlayerPrefs.GetString("nombres", "x,x,x,x,x,x,x,x,x,x");
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
            string[] nombres = new string[10];
            int[] puntuaciones = new int[10];
            if (modoInfinito)
            {
                Array.Copy(obtenerArrayNombres(true), nombres, 10);
                Array.Copy(obtenerArrayPuntuaciones(true), puntuaciones, 10);
            }
            else
            {
                Array.Copy(obtenerArrayNombres(false), nombres, 10);
                Array.Copy(obtenerArrayPuntuaciones(false), puntuaciones, 10);
            }
                
            if (posicion == puntuaciones.Length - 1){
                puntuaciones[posicion] = puntuacion;
                nombres[posicion] = nombre;
            }
            else{
                Array.Copy(puntuaciones, posicion, puntuaciones, posicion + 1, puntuaciones.Length - posicion - 1);
                Array.Copy(nombres, posicion, nombres, posicion + 1, nombres.Length - posicion - 1);
                puntuaciones[posicion] = puntuacion;
                nombres[posicion] = nombre;
            }

            if (modoInfinito)
            {
                PlayerPrefs.SetString("infinito", "true");
                PlayerPrefs.SetString("puntuaciones2", crearStringPuntuaciones(puntuaciones));
                PlayerPrefs.SetString("nombres2", crearStringNombres(nombres));
                PlayerPrefs.SetInt("marcarPosicion2", posicion);
            }
            else
            {
                PlayerPrefs.SetString("infinito", "false");
                PlayerPrefs.SetString("puntuaciones", crearStringPuntuaciones(puntuaciones));
                PlayerPrefs.SetString("nombres", crearStringNombres(nombres));
                PlayerPrefs.SetInt("marcarPosicion", posicion);
            }
            
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
