using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutinas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Semaforo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Semaforo()
    {
        Debug.Log("Verde");
        yield return new WaitForSeconds(2);
        Debug.Log("Amarillo");
        yield return new WaitForSeconds(2);
        Debug.Log("Rojo");

    }
}
