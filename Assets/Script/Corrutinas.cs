using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutinas : MonoBehaviour
{
    private bool corrutinaAbierta;
    // la corrutina es un  metodo metiendole tiempos de espera 
    void Start()
    {
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S) && corrutinaAbierta == false)

        {
            StartCoroutine(Semaforo());
            corrutinaAbierta = true;
        }
    }

    IEnumerator Semaforo()
    {
        while (1==1)
        {

        
            Debug.Log("Verde");
        
            yield return new WaitForSeconds(2);
        
            Debug.Log("Amarillo");
        
            yield return new WaitForSeconds(2);
        
            Debug.Log("Rojo");

        }

    }
}
