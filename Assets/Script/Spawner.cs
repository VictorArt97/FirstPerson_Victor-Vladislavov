using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Spawnear cada 2 segundos un zombie aleatorio entre distintos puntos de Spawn

    [SerializeField] private Transform [] puntosSpawn;
    [SerializeField] private Enemigo enemigoPrefab; 

    void Update()
    {
        
    }

    IEnumerator Generador()
    {
        while (1 == 1)
        {
            // saca una copia en el punto 0 con rotacion ninguna 
            Instantiate(enemigoPrefab, puntosSpawn[0].position,Quaternion.identity);

        }
    }
}
