using UnityEngine;

public class movimientoHorizontal : MonoBehaviour {

    public Transform objetivo;
    public float velocidad;
    private Vector3 posIzda;
    private Vector3 posDrcha;

	void Start () {
        objetivo.parent = null; //para q no se mueva junto con la plataforma
        posIzda = new Vector3(4.5f, transform.position.y, 0);
        posDrcha = new Vector3(-4.5f, transform.position.y, 0);
    }
	
	void Update () {
        if (transform.position != objetivo.position)
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
        else if (transform.position == posDrcha)
            objetivo.position = posIzda;
        else
            objetivo.position = posDrcha;
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
