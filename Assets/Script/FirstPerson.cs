using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private Camera cam;

    CharacterController controller;
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

       
    }
}
