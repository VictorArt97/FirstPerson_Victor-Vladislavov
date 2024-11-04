using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstPerson : MonoBehaviour
{

    [SerializeField] private float vidas;
   
    [SerializeField] private float velocidadMovimiento;
    private Camera cam;
    
    [Header("Movimiento Jugador")]
    CharacterController controller;
    [SerializeField] private float escalaGravedad;
    private Vector3 movimientoVerticar;
    [SerializeField] private float alturaSalto;

  
    [Header("Deteccion del suelo")]
    [SerializeField] private Transform pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;

   
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    void Update()
    {
       float h = Input.GetAxisRaw("Horizontal");
       float v = Input.GetAxisRaw("Vertical");
       
        Vector2 input = new Vector2 (h, v).normalized;
       
        // Vector3 movimiento = new Vector3(h,0,v).normalized;

        if (input.sqrMagnitude >0)      // es mejor que poner el magnitudes porque no usa la raiz cuadrada
        {
         
            // se calcula el angfulo al que tengo que rotarme en funcion de los unputs y orientacion de camara

            float anguloRotacion = Mathf.Atan2 (input.x, input.y)*Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3 (0,anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
       
            controller.Move(movimiento*velocidadMovimiento*Time.deltaTime);          
          
        }
        DeteccionSuelo();
        AplicarGravedad();
    } 
    private void AplicarGravedad()
    {
            movimientoVerticar.y += escalaGravedad * Time.deltaTime;
        controller.Move (movimientoVerticar * Time.deltaTime);


    }

    private void DeteccionSuelo ()
    {
        // tengo que lanzar una gola de deteccion en mis pies para detectar si hay suelo 
       Collider[] collsDetectados= Physics.OverlapSphere(pies.position,radioDeteccion,queEsSuelo);

        if (collsDetectados.Length>0)
        {
            movimientoVerticar.y =0;
            Saltar();
        }
          
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVerticar.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
        }


    }


    public void RecibirDanho(float danhoRecibido)
    {

        vidas -= danhoRecibido;

    }

    // sirve para dibujar una forma
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;    
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
}
