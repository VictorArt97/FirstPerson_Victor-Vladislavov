using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoFinal : MonoBehaviour
{
    [SerializeField] private float danioAtaque;

    private NavMeshAgent agente;
    private FirstPerson player;

    private Animator animator;
    private bool OpenWindow=false;

    [SerializeField] private Transform puntoDeAtaque;
    [SerializeField] private float radioDeAtaque;
    [SerializeField] private LayerMask queEsAtacable;
    private bool danioRealizado = false;

    [SerializeField] private float vidaFinalBoss;
    private AudioSource audioManager;

    public float VidaFinalBoss { get => vidaFinalBoss; set => vidaFinalBoss = value; }

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player= GameObject.FindObjectOfType<FirstPerson>();
        audioManager = GetComponent<AudioSource>();
    }


    void Update()
    {
        Perseguir();
        if (OpenWindow && danioRealizado == false)
        {
            DetectarAlJugador();
        }
    }
    private void DetectarAlJugador()
    {
        Collider[] colsDetectados = Physics.OverlapSphere(puntoDeAtaque.position, radioDeAtaque, queEsAtacable);

        if(colsDetectados.Length > 0)
        {
            for(int i = 0; i < colsDetectados.Length; i++)
            {
                colsDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danioAtaque);
            }
            danioRealizado = true;
        }
    }
    private void Perseguir()
    {
        agente.SetDestination(player.transform.position);
        if (!agente.pathPending && agente.remainingDistance<= agente.stoppingDistance)
        {
            agente.isStopped = true;
            animator.SetBool("attacking",true);
            EnfocarAlJugador();
        }
    }
    private void EnfocarAlJugador()
    {
        Vector3 direccionAPlayer = (player.transform.position - this.gameObject.transform.position).normalized;
        direccionAPlayer.y = 0;
        transform.rotation= Quaternion.LookRotation(direccionAPlayer);
    }

    private void EndOfAttack()
    {
        agente.isStopped= false;
        danioRealizado = false;
        animator.SetBool("attacking", false);
    }

    private void OpenAttackWindow()
    {
        OpenWindow=true;
    }

    private void Muerte()
    {
        animator.enabled = false;
        audioManager.enabled = false;
        Destroy(gameObject, 20);
    }
    
    private void CloseAttackWindow()
    {
        OpenWindow=false;
    }
}
