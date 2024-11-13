using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour
{
   private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void abrir()    // control y clicar te lleva al script del metodo 
    {
        anim.SetTrigger("Abriendo_Caja");
    }
}
