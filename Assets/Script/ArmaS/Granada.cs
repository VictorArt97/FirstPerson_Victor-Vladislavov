using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    // al nacer a�adir un Impulso en su RigidBody 
    // en la direccion que marca su EJE Z ( transform.forward) 

    Rigidbody rb;
    [SerializeField] private float fuerzaDisparo;
    [SerializeField] private float tiempoDestruccion;

    [SerializeField]private  float radioExplosion;
    [SerializeField]private  LayerMask QueEsDaniable;

    [SerializeField] private GameObject explosionPrefab;
    
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward.normalized * fuerzaDisparo, ForceMode.Impulse);
        Destroy(gameObject, tiempoDestruccion);
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // instanciar una copia de la explosion sin rotacion
        Debug.Log("me voy de este mundo");

        // para hacerle da�o al que colisiona 
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioExplosion, QueEsDaniable);
        if ( collsDetectados.Length > 0)
        {
            //for (int i = 0; i < collsDetectados.Length; i++) 
            foreach(Collider coll in collsDetectados)
            {
                coll.GetComponent<EnemyPart>().Explotar();   /// dehabilito el movimiento del enemigo impactado 
                coll.GetComponent<Rigidbody>().isKinematic = false;   // dejo los huesos en dinamico
                coll.GetComponent<Rigidbody>().AddExplosionForce(60, transform.position, radioExplosion, 23.5f,ForceMode.Impulse); // aplico explosion

            }
        }
    }
}
