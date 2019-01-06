using UnityEngine;

public class movimientoHorizontal : MonoBehaviour {

    public float velocidad;
    private Vector3 irPos;
    private Vector3 posIzda;
    private Vector3 posDrcha;

	void Start () {
        posIzda = new Vector3(4.5f, transform.position.y, 0);
        posDrcha = new Vector3(-4.5f, transform.position.y, 0);
        int num = Random.Range(0, 2);
        if (num == 0)
            irPos = posIzda;
        else
            irPos = posDrcha;
    }
	
	void Update () {
        if (transform.position != irPos)
            transform.position = Vector3.MoveTowards(transform.position, irPos, velocidad * Time.deltaTime);
        else if (transform.position == posDrcha)
            irPos = posIzda;
        else
            irPos = posDrcha;
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
