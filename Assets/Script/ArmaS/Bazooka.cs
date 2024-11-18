using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private GameObject granadaPrefab;



    //cuandop cliquesm click izq 
    // instanciar una copia del prefab grenade en SpawnPoint 
    //Por ahora rotacion quaternion.Identity
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {

            // creo una instancia con la misma orientacion que el cañon 
            Instantiate(granadaPrefab, puntoSpawn.position, puntoSpawn.rotation);
            
        }
    }
}
