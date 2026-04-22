using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject dianaPrefab;
    public float tiempoEntreSpawns = 2f;
    public int cantidadDianas = 6;

    void Start()
    {
        StartCoroutine(SpawnearDianas());
    }

    IEnumerator SpawnearDianas()
    {
        List<GameObject> listadianas = new List<GameObject>();

        for (int i = 0; i < cantidadDianas; i++)
        {
            Vector3 posicion = transform.position + new Vector3(i * 5f, 0, 0);
            GameObject diana = Instantiate(dianaPrefab, posicion, transform.rotation);
            listadianas.Add(diana);

            // Actualiza el array en el manager usando el Singleton
            GunGameManager.instance.dianas = listadianas.ToArray();

            yield return null;
        }
    }
}