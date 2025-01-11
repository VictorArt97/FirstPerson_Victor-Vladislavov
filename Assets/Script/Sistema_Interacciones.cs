using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering;

public class Sistema_Interacciones : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private GameObject equipamientoRyuki;
    Transform interactuableActual;

    void Update()
    {
        // lanzar un raycast por cada frame desde la main camera hacia adelante
        // si hemos hitteado algo , preguntar si ese algo tiene el tag interactuable
        // si es asi , pone un debug log "detectado"        

       if( Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
       {
            if (hit.transform.TryGetComponent(out CajaMunicion scriptCaja))    // sirve para que no te puedas equivocar con lo del tag 
            {              
               

                // aquello que he hitteado es la caja 
                // acceder a su script y Activaro ( es un componente )

                interactuableActual = hit.transform;
                interactuableActual.GetComponent<Outline>().enabled=true;
                
                
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                   // scriptCaja.Abrir();
                    Debug.Log("DECK EQUIPADO");
                    equipamientoRyuki.SetActive(true);
                       
                    //crear un metodo en el script caja municon llamado abrir 
                        // llamar a dicho metodo desde dicho script
                        //implemetnar el metodo abrir ---> obtener el animator 
                        // activar el trigger del animator  anim.SetTrigger

                }
            }
           
       }
            else if(interactuableActual)
            {
                interactuableActual.GetComponent<Outline>().enabled = false;
                interactuableActual=null;
            }
    }
}
