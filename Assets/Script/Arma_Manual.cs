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
           if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<EnemyPart>().RecibirDanio(misDatos.danioAtaque);

                }
                    // generar un metodo recibir daño en el script enemgio con un parametro tipo float
                    //desde este script ejecutar el metodo recibir daño del enemigo
                    // para ello necesitamos un daño.obtenla del SO
                    // si el enemigo se queda sin vida , destruirlo.
            }

        }

    }
}
