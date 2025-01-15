using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Arma_Automatica : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private Camera cam;
   // private AudioSource manager;
    private float timer = 0;
    void Start()
    {
        cam = Camera.main;
       // manager = GetComponent<AudioSource>();
        //misDatos.cadenciaAtaque;
    }

  
    void Update()
    {
        timer += 1* Time.deltaTime;
       
       // manager.Play();
        // implementa un timer 
        //vas a poder disparar siempre y cuando el timer sea superior a "cadenciaAtaque" 
        //reiniciar el timer  si has disparado

        if(Input.GetMouseButton(0)&& timer > misDatos.cadenciaAtaque)
        {
            
               
                    system.Play();   // ejecutar sistema particulas
                    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
                    {
                        if (hitInfo.transform.CompareTag("ParteEnemigo"))
                        {
                            hitInfo.transform.GetComponent<EnemyPart>().RecibirDanio(misDatos.danioAtaque);

                        }              
                    }
                    timer = 0;
                
        }
    }
}
