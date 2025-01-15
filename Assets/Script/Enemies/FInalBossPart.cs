using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInalBossPart : MonoBehaviour
{
    [SerializeField] private EnemigoFinal mainScript;
    [SerializeField] private float multiplicadorDanio;   // para hacer que el darle en x parte del cuerpo , hace un da�o distinto 

    public void RecibirDanio(float danioRecibido)
    {
        mainScript.VidaFinalBoss -= danioRecibido * multiplicadorDanio;

        if (mainScript.VidaFinalBoss <= 0)
        {
            mainScript.Muerte();
        }

    }
    
}
