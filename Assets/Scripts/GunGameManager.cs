using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGameManager : MonoBehaviour
{
    public static GunGameManager instance;

    public GameObject[] dianas;
    private int rotasPorDisparo = 0;

    public int balasMaximas = 10;
    private int balasRestantes;

    void Awake()
    {
        instance = this;
        balasRestantes = balasMaximas;
    }

    public bool PuedeDisparar()
    {
        return balasRestantes > 0;
    }

    public void GastarBala()
    {
        balasRestantes--;
        Debug.Log("Balas restantes: " + balasRestantes);
    }

    public void DianaRota()
    {
        rotasPorDisparo++;
        Debug.Log("Progreso: " + rotasPorDisparo + "/" + dianas.Length);
    }

    public void CheckFinish()
    {
        int desactivadas = 0;

        foreach (GameObject diana in dianas)
        {
            if (diana == null) continue;
            if (!diana.activeSelf) desactivadas++;
        }

        if (desactivadas == dianas.Length)
        {
            if (rotasPorDisparo == dianas.Length)
                Debug.Log("You Win!");
            else
                Debug.Log("Rompiste " + rotasPorDisparo + "/" + dianas.Length + ", has perdido!");
        }
    }
}