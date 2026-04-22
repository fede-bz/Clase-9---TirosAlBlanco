using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Diana"))
        {
            GameObject dianaRaiz = otro.transform.root.gameObject;
            dianaRaiz.SetActive(false);

            GunGameManager.instance.DianaRota();
            GunGameManager.instance.CheckFinish();

            Destroy(gameObject);
        }
    }
}