using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField] private Image barradevida;
    [SerializeField] private GameObject UIBoss;
   // [SerializeField] private AudioSource canvas;

    public float VidaFinalBoss { get => vidaFinalBoss; set => vidaFinalBoss = value; }

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player= GameObject.FindObjectOfType<FirstPerson>();
        audioManager = GetComponent<AudioSource>();
      //  canvas= GetComponent<AudioSource>();
        //canvas.Stop();
        UIBoss.SetActive(true);
        audioManager.playOnAwake = true;
    }


    void Update()
    {
        Perseguir();
        if (OpenWindow && danioRealizado == false)
        {
            DetectarAlJugador();
        }
        VidaUI();
    }

    //private void Awake()
    //{
    //    canvas.Stop();
    //    UIBoss.SetActive(true);
    //    audioManager.playOnAwake = true;
    //}
    private void VidaUI()
    {
        barradevida.fillAmount = vidaFinalBoss / 300;
    }
    private void DetectarAlJugador()
    {
        Collider[] colsDetectados = Physics.OverlapSphere(puntoDeAtaque.position, radioDeAtaque, queEsAtacable);

        if(colsDetectados.Length > 0)
        {
            for(int i = 0; i < colsDetectados.Length; i++)
            {
                Debug.Log("Daño a" + colsDetectados[i].name);
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

    public void Muerte()
    {
        animator.enabled = false;
        audioManager.enabled = false;
        SceneManager.LoadScene(4);   // cargar escena de victoria 
        Destroy(gameObject, 20);

    }

    //public void RecibirDanio(float danioRecibido)
    //{
    //    mainScript.VidaEnemigo -= danioRecibido * multiplicadorDanio;

    //    if (mainScript.VidaEnemigo <= 0)
    //    {
    //        mainScript.Morir();
    //    }

    //}

    private void CloseAttackWindow()
    {
        OpenWindow=false;
    }
}
