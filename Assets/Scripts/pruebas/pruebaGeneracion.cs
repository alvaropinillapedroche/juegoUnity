using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaGeneracion : MonoBehaviour {

    public GameObject plataforma;
    public GameObject platObli;

    void Awake()
    {
        /*Vector3 pos = new Vector3(1.03f, 299.15f, 0);
        Vector3 pos2 = new Vector3(1.03f, 301f, 0);
        GameObject plat = Instantiate(plataforma, pos, transform.rotation);
        GameObject plat2 = Instantiate(plataforma, pos2, transform.rotation);
        Destroy(plat.GetComponent<Rigidbody2D>());*/
        prueba();
    }

    private void prueba()
    {
        ArrayList array = new ArrayList();
        Vector3 pos = new Vector3(1.03f, 299.15f, 0);
        Vector3 pos2 = new Vector3(1.03f, 301f, 0);
        GameObject plat = Instantiate(plataforma, pos, transform.rotation);
        GameObject plat2 = Instantiate(plataforma, pos2, transform.rotation);
        array.Add(plat);
        array.Add(plat2);

        for (int i = 0; i < array.Count; i++)
        {
            GameObject obj = (GameObject)array[i];
            obj.tag = "puesta";
            Destroy(obj.GetComponent<Rigidbody2D>());
        }
    }
}
