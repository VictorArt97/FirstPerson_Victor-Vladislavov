using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    // refernecia todos los gameobjects que tengas como hijos en el WeaponHolder

    // si damos a la tecla 1 , activas la primera arma y el resto se quedan desactivadas    // .SetActive

    // lo mismo con 2 

    [SerializeField] private GameObject[] armas;
    int indiceArmaActual= 0;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarArma(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarArma(1);
        } 
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CambiarArma(2);
        }
    }

    private void CambiarArma(int proximoArma)
    {
        armas[indiceArmaActual].SetActive(false);
        indiceArmaActual = proximoArma;
        armas[indiceArmaActual].SetActive(true);
    }

    
}
