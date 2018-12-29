using UnityEngine;

public class Doodler : MonoBehaviour{

    public float velocidad;
    public bool salto;
    public bool disparo;

    private Rigidbody2D rb2d;
    private SpriteRenderer render;
    private Animator anim;

    private float segundos;
    public float segundosAContar;

    void Start(){
        velocidad = 8;
        salto = false;

        rb2d = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        anim.SetBool("salto", salto);
        anim.SetBool("disparo", disparo);
    }

    void FixedUpdate(){
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * velocidad * Time.deltaTime);

        if (h < 0)
            render.flipX = true;
        else if (h > 0)
            render.flipX = false;

        //Animación y gravedad al caer
        if (rb2d.velocity.y <= 0)
        {
            rb2d.gravityScale = 2;
            salto = false;
        }
        else
            rb2d.gravityScale = 1;

        //Efecto lateral al salir de la pantalla
        if (transform.position.x > 5.70f)
            transform.position = new Vector3(-5.30f, transform.position.y, 0);
        else if (transform.position.x <= -5.30f)
            transform.position = new Vector3(5.70f, transform.position.y, 0);

       
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            disparo = true;
            segundos = 0;
            salto = false;
        }
        else if (segundos >= segundosAContar) //Para mostrar animación durante un tiempo
        {
            disparo = false;
            
        }
        segundos += Time.deltaTime;
    
    }

    public void iniciarDisparar()
    {
        disparo = true;
    }
}
