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
    [SerializeField] GameObject[] uI;
    int indiceUIActual= 0;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarConTeclado();
        CambiarConRaton();


    }

    private void CambiarConRaton()
    {

        //
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
       if (ScrollWheel> 0) // anterior 
       {
            CambiarMira(indiceUIActual - 1);
            CambiarArma(indiceArmaActual - 1);
       }
        
       if (ScrollWheel< 0) // siguiente
       {
            CambiarMira(indiceUIActual + 1);
            CambiarArma(indiceArmaActual + 1);

       }
    }
    private void CambiarConTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);
            CambiarMira(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambiarArma(1);
            CambiarMira(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambiarArma(2);
            CambiarMira(2);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambiarArma(3);
            CambiarMira(3);
        }
    }

    private void CambiarArma(int nuevoIndice)
    {

      //  indiceArmaActual = nuevoIndice;

        // solo si es un indice valido , puede cambiar de arma
        if(nuevoIndice >= 0 && nuevoIndice < armas.Length)
        {
            armas[indiceArmaActual].SetActive(false);

            indiceArmaActual = nuevoIndice;     
            
            armas[indiceArmaActual].SetActive(true);
        }
    }




   private void CambiarMira(int proximaInterfaz)
    {
       // uI[indiceUIActual].SetActive(false);
       // indiceUIActual = proximaInterfaz;



       // uI[indiceUIActual].SetActive(true);

        if (proximaInterfaz >= 0 && proximaInterfaz < uI.Length)
        {
            uI[indiceUIActual].SetActive(false);

            indiceUIActual = proximaInterfaz ;
            uI[indiceUIActual].SetActive(true) ;
        }

    }

    
}
