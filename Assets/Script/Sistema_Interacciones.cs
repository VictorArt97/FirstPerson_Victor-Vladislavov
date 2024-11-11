using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Sistema_Interacciones : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distanciaInteraccion;

    Transform interactuableActual;

    void Start()
    {
        
    }


    void Update()
    {
        // lanzar un raycast por cada frame desde la main camera hacia adelante
        // si hemos hitteado algo , preguntar si ese algo tiene el tag interactuable
        // si es asi , pone un debug log "detectado" 

        

       if( Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
        {
            if (hit.transform.CompareTag("Interaccionable"))
            {              
                Debug.Log("lolololololololoololololo");

                // aquello que he hitteado es la caja 
                // acceder a su script y Activaro ( es un componente )

                interactuableActual = hit.transform;
                interactuableActual.GetComponent<Outline>().enabled=true;
            }
            else if(interactuableActual)
            {
                interactuableActual.GetComponent<Outline>().enabled = false;
                interactuableActual=null;
            }
        }
    }
}
