using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    [SerializeField] private float danhoAtaque;

   
    private NavMeshAgent agent;
    private FirstPerson player;

    private Animator anim;
    private bool ventanaAbierta = false;

    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    private bool danhoRealizado = false;

    private Rigidbody[] huesos;    // array de rigidBodys



    [SerializeField] private float vidaEnemigo;

    public float VidaEnemigo { get => vidaEnemigo; set => vidaEnemigo = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        huesos= GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindObjectOfType<FirstPerson>();
        
        EstadoHuesos(true);
    }

   
    void Update()
    {
        Perseguir();

        // solo si la ventana esta abierta y aun no hemos hecho daño
        if (ventanaAbierta && danhoRealizado == false)
        {
            DetectarJugador();
        
        }

    }

    private void DetectarJugador()
    {
        // necesitas referenciar el pivot del attackPoint 
        // crear una variable que represente el radio de ataque 
        // variagble que represente la layer a la que afecta 
        // completar los parametros de entrada
        Collider [] colsDetectados= Physics.OverlapSphere(AttackPoint.position, radioAtaque, queEsDanhable);

        // si hemos detectado al menos 1 colider mide ya mas que 0 ( ya que este if significa que la longitud de los coliders es mayor que 0)
        if ( colsDetectados.Length > 0 )
        {
            for (int i = 0; i < colsDetectados.Length; i++)
            {

                // esta variable es del tipo first person al ser lo mas especifico

                colsDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoAtaque);

               
            }
            danhoRealizado= true;
        }
    }

    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);

        // si la distancia que nos queda hacia el objeto cae por debjado del stoppingDistance
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("attacking", true);
        }
    }

    #region Eventos de animacion
    // funciona con evento de animacion ( todavia no porque no he terminado)
    private void FinAtaque()
    {
         agent.isStopped= false;
        danhoRealizado = false;
        anim.SetBool("attacking",false);
    }
    private void AbrirVentanaAtaque()

    #endregion
    {
        ventanaAbierta=true;
    }
    public void Morir()
    {

        // enabled sirve para activar/desactivar componentres 
        // setActive sirve para activar /Desactivar un Objeto entero
        anim.enabled = false;
        agent.enabled = false;
        EstadoHuesos(false);
        Destroy(gameObject, 10);
    }

    private void EstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }

   
    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;

    }
}
