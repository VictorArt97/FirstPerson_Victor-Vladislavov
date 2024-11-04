using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    private NavMeshAgent agent;
    private FirstPerson player;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        player = GameObject.FindObjectOfType<FirstPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);


        // si la distancia que nos queda hacia el objeto cae por debjado del stoppingDistance
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("attacking",true);
        }
    }

    #region Eventos de animacion
    // funciona con evento de animacion ( todavia no porque no he terminado)
    private void FinAtaque()
    {
         agent.isStopped= false;
        anim.SetBool("attacking",false);
    }

    #endregion
    private void Atacar()
    {

    }
}
