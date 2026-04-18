using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject dianaPrefab;
    public float tiempoEntreSpawns = 2f;
    public int cantidadDianas = 6;
    public GunGameManager manager;

    void Start()
    {
        StartCoroutine(SpawnearDianas());
    }

    IEnumerator SpawnearDianas()
    {
        List<GameObject> listadianas = new List<GameObject>();

        for (int i = 0; i < cantidadDianas; i++)
        {
            // Cada diana spawnea un poco más a la derecha
            Vector3 posicion = transform.position + new Vector3(i * 5f, 0, 0);

            GameObject diana = Instantiate(dianaPrefab, posicion, transform.rotation);
            diana.GetComponent<MovimientoDianas>().manager = manager;
            listadianas.Add(diana);

            // Actualiza el array en cada spawn
            manager.dianas = listadianas.ToArray();

            yield return null;
        }
    }
}