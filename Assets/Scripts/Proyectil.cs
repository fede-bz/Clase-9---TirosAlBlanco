using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f;
    public GunGameManager manager;

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

            manager.DianaRota();    // Cuenta la diana rota
            manager.CheckFinish();  // Verifica si terminó el juego

            Destroy(gameObject);
        }
    }
}