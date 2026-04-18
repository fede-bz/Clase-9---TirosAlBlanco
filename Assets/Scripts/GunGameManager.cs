using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGameManager : MonoBehaviour
{
    public GameObject[] dianas;
    private int rotasPorDisparo = 0;

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