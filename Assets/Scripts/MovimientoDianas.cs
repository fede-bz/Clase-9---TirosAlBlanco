using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDianas : MonoBehaviour
{
    public float velocidad = 3f;
    public GunGameManager manager;

    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime, Space.World);

        if (transform.position.x < -15f)
        {
            Debug.Log("Objeto que se desactiva: " + gameObject.name);
            gameObject.SetActive(false);

            if (manager != null)
                manager.CheckFinish();
        }
    }
}