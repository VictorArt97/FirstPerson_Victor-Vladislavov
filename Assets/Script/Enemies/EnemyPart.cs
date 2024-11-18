using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPart : MonoBehaviour
{
    
    [SerializeField] private Enemigo mainScript;
    [SerializeField] private float multiplicadorDanio;   // para hacer que el darle en x parte del cuerpo , hace un daño distinto 

    public void RecibirDanio(float danioRecibido)
    {
        mainScript.VidaEnemigo -= danioRecibido* multiplicadorDanio;

        if (mainScript.VidaEnemigo <= 0)
        {
            mainScript.Morir();
        }

    }
    public void Explotar()
    {
        mainScript.GetComponent<Animator>().enabled = false;
        mainScript.GetComponent<NavMeshAgent>().enabled = false;
        mainScript.enabled = false;

    }
}
