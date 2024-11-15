using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    
    [SerializeField] private Enemigo mainScript;
    [SerializeField] private float multiplicadorDanio;   // para hacer que el darle en x parte del cuerpo , hace un daño distinto 


    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void RecibirDanio(float danioRecibido)
    {
        mainScript.VidaEnemigo -= danioRecibido* multiplicadorDanio;

        if (mainScript.VidaEnemigo <= 0)
        {
            mainScript.Morir();
        }

    }
}
