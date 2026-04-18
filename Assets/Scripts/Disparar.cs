using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject proyectilPrefab;  // El prefab del proyectil
    public Transform puntoDeDisparo;    // Desde dónde sale el proyectil
    public GunGameManager manager;      // Referencia al manager

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Instancia el proyectil en el punto de disparo
            // con la rotación del cañón
            GameObject proyectil = Instantiate(
                proyectilPrefab,
                puntoDeDisparo.position,
                transform.rotation
            );

            // Le pasa la referencia al manager
            proyectil.GetComponent<Proyectil>().manager = manager;
        }
    }
}