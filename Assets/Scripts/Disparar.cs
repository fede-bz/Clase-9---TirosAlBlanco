using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDeDisparo;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GunGameManager.instance.PuedeDisparar())
            {
                GunGameManager.instance.GastarBala();
                Instantiate(
                    proyectilPrefab,
                    puntoDeDisparo.position,
                    transform.rotation
                );
            }
        }
    }
}