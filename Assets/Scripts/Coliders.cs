using UnityEngine;

public class Coliders : MonoBehaviour
{
    public float impulso;
    public float impulsoMuelle;
    public float impulsoCama;

    private Rigidbody2D rb2d;

    private AudioSource sonido;
    public AudioClip camaAudio;
    public AudioClip muelleAudio;
    void Start()
    {
        impulso = 8;
        impulsoMuelle = 15;
        impulsoCama = 20;
        rb2d = GetComponent<Rigidbody2D>();
        sonido = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if ((c.gameObject.tag == "plataforma" || c.gameObject.tag == "obligatoria") && rb2d.velocity.y <= 0)
        {
            rb2d.AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
            if (!GetComponent<Doodler>().disparo)
                GetComponent<Doodler>().salto = true;
            sonido.Play();
        }
        else if (c.gameObject.tag == "muelle" && rb2d.velocity.y <= 0)
        {
            rb2d.AddForce(Vector2.up * impulsoMuelle, ForceMode2D.Impulse);
            if (!GetComponent<Doodler>().disparo)
                GetComponent<Doodler>().salto = true;
            sonido.PlayOneShot(muelleAudio);
        }
        else if (c.gameObject.tag == "cama" && rb2d.velocity.y <= 0)
        {
            rb2d.AddForce(Vector2.up * impulsoCama, ForceMode2D.Impulse);
            if (!GetComponent<Doodler>().disparo)
                GetComponent<Doodler>().salto = true;
            sonido.PlayOneShot(camaAudio);
        }
        else if ((c.gameObject.tag == "plataformaBlanca" || c.gameObject.tag == "obligatoriaBlanca") && rb2d.velocity.y <= 0)
        {
            rb2d.AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
            if (!GetComponent<Doodler>().disparo)
                GetComponent<Doodler>().salto = true;
            sonido.Play();
            Destroy(c.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemigo") || other.gameObject.CompareTag("obligatorioEnemigo"))
        {
            transform.position = new Vector3(transform.position.x, -6, 0);
        }
    }
}