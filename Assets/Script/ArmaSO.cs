using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Arma")]
public class ArmaSO : ScriptableObject
{


    public int balasCargador;
    public int balasBolsa;
    public float distanciaAtaque;
    public float dañoAtaque;
    public float cadenciaAtaque;   // ratio de disparo entre tiro y tiro (balas por segundo)


}
