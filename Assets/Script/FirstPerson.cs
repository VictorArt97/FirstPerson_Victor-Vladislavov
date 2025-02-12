using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstPerson : MonoBehaviour
{

   // [Heather("Datos y demas Jugador")]// --------------------------------------------------------------------------------------------

    [SerializeField] private float vidas; 
    private Camera cam;
    

    [Header("Movimiento Jugador")]// -----------------------------------------------------------------------------------------------


    private float velocidadIncial;
    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;
    [SerializeField] private float escalaGravedad;
    private Vector3 movimientoVertical;
    [SerializeField] private float alturaSalto;

    [SerializeField] private Image barradevida;

  
  //  [Header("Deteccion del suelo")]

    [SerializeField] private Transform pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;

    

    // ataque mele 



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       controller = GetComponent<CharacterController>();
        cam = Camera.main;
        velocidadIncial = velocidadMovimiento;

        
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v).normalized;

        // Vector3 movimiento = new Vector3(h,0,v).normalized;



        if (input.sqrMagnitude > 0)                                                                                    // es mejor que poner el magnitudes porque no usa la raiz cuadrada
        {

            /// se calcula el angfulo al que tengo que rotarme en funcion de los unputs y orientacion de camara

            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);

        }

        DeteccionSuelo();
        AplicarGravedad();
        Sprint();

        // actualizar vida en canva
        VidaUI();

    }

    public void VidaUI()
    {
        barradevida.fillAmount = vidas/100;
    }
    private void AplicarGravedad()
    {
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        controller.Move (movimientoVertical * Time.deltaTime);
    }
   private void Sprint()    /// al pulsar shift el personaje acellera su velocidad x2
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidadMovimiento *=2;
            // new WaitForSeconds(2);
            //velocidadMovimiento = velocidadIncial;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadMovimiento = velocidadIncial;
        }
    }
    
    private void DeteccionSuelo ()
    {
        // tengo que lanzar una gola de deteccion en mis pies para detectar si hay suelo 
       Collider[] collsDetectados= Physics.OverlapSphere(pies.position,radioDeteccion,queEsSuelo);

        if (collsDetectados.Length>0)
        {
            movimientoVertical.y =0;
            Saltar();
        }
          
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
        }


    }
    public void RecibirDanho(float danhoRecibido)
    {

        vidas -= danhoRecibido;
        if (vidas < 0)
        {
            SceneManager.LoadScene(3);
            Destroy(gameObject);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
       

    }

    // como un dollision enter pero con el character controler
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("ParteEnemigo"))
        {
           Rigidbody rbEnemigo= hit.gameObject.GetComponent<Rigidbody>();
            Vector3 direccionFuerza= hit.transform.position - gameObject.transform.position;
            rbEnemigo.AddForce(direccionFuerza.normalized * 50 , ForceMode.Impulse);
        }
    }

    // sirve para dibujar una forma
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;    
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
}
