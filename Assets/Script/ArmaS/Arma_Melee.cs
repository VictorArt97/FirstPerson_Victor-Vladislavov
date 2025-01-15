using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Arma_Melee : MonoBehaviour
{

   // [SerializeField] private float distanciaAtaque;
   // [SerializeField] private float delayAtaque;
   // [SerializeField] private float velocidadDeAtaque;
    [SerializeField] private float danioAtaque;
    [SerializeField] private LayerMask queEsDaniable;

    [SerializeField] private AudioClip sonidoEspada;
    private bool atacando = false;
    private bool preparadoParaAtacar = true;
    public int cuentaAtaque;


    [SerializeField] private Camera cam;
    [SerializeField] private ArmaSO misDatos;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        gameObject.GetComponent<Animator>().SetTrigger("Attacking");     

    //    }

    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "enemigo")
    //    {
    //        other.GetComponent<Enemigo>().VidaEnemigo -= danioAtaque;
    //    }
    //}
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attacking");

            //system.Play();   // ejecutar sistema particulas
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<EnemyPart>().RecibirDanio(misDatos.danioAtaque);

                }

                if (hitInfo.transform.CompareTag("finalBoss"))
                {
                    hitInfo.transform.GetComponent<FInalBossPart>().RecibirDanio(misDatos.danioAtaque);

                }
                // generar un metodo recibir daño en el script enemgio con un parametro tipo float
                //desde este script ejecutar el metodo recibir daño del enemigo
                // para ello necesitamos un daño.obtenla del SO
                // si el enemigo se queda sin vida , destruirlo.
            }

        }
    }
    
}
