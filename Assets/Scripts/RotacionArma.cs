using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionArma : MonoBehaviour
{
    public float sensibilidad = 50f; // Qué tan rápido gira

    void Update()
    {
        // Obtiene el movimiento de la rueda del mouse
        float rueda = Input.GetAxis("Mouse ScrollWheel");

        // Rota el GameObject en el eje Y según la rueda
        transform.Rotate(0, rueda * sensibilidad, 0);
    }
}