using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDianas : MonoBehaviour
{
    public float velocidad = 3f;

    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime, Space.World);

        if (transform.position.x < -15f)
        {
            gameObject.SetActive(false);
            GunGameManager.instance.CheckFinish();
        }
    }
}