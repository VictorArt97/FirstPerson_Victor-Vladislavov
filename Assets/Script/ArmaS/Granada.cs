using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    // al nacer añadir un Impulso en su RigidBody 
    // en la direccion que marca su EJE Z ( transform.forward) 

    Rigidbody rb;
    [SerializeField] private float fuerzaDisparo;
    [SerializeField] private float tiempoDestruccion;

    [SerializeField] float radioExplosion;
    [SerializeField] LayerMask QueEsDaniable;
    
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward.normalized * fuerzaDisparo, ForceMode.Impulse);
        Destroy(gameObject, tiempoDestruccion);
    }

    
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Debug.Log("me voy de este mundo");

        // para hacerle daño al que colisiona 
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioExplosion, QueEsDaniable);
        if ( collsDetectados.Length > 0)
        {
            
        }
    }
}
