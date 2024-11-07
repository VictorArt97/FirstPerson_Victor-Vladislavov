using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma_Manual : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        // cam es la camara principal de la escena "MainCamera"
        cam= Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           system.Play();   // ejecutar sistema particulas
           if (Physics.Raycast(cam.transform.position, -cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque);)
            {
                
            }

        }

    }
}
