using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema_Interacciones : MonoBehaviour
{
    [SerializeField] private Transform pov;
    [SerializeField] private float areaDeteccion;
    [SerializeField] private LayerMask queEsInteractuable;


    void Start()
    {
        
    }


    void Update()
    {
        // lanzar un raycast por cada frame desde la main camera hacia adelante
        // si hemos hitteado algo , preguntar si ese algo tiene el tag interactuable
        // si es asi , pone un debug log "detectado" 

        Collider[] collsDetectados = Physics.OverlapSphere(pov.position, areaDeteccion, queEsInteractuable);
        if (collsDetectados.Length > 0)
        {
            Debug.Log("Encontrado");
        }

       // Physics.Raycast(pov.transform.position, -pov.transform.forward, out RaycastHit hitInfo,)
    }
}
