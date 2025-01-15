using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Spawnear cada 2 segundos un zombie aleatorio entre distintos puntos de Spawn

    [SerializeField] private Transform [] puntosSpawn;
    [SerializeField] private Enemigo enemigoPrefab;
    private int contador;

    void Start()
    {
       
        StartCoroutine(Generador());
    
    }

    private IEnumerator Generador()
    {
        while (contador<=15)
        {
            // saca una copia en el punto 0 con rotacion ninguna 
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position,Quaternion.identity);
            yield return new WaitForSeconds(2);
            contador++;
            
            

        }
        //Debug.Log("Se acabo");
        // para porcentaje if ( rng <= 0.3f)   // 10%

        // if ( rng > 0.2f && rng <= 0.9f) // 70%    ( restar el segundo con el primero)
    }
}
