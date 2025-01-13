using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class SistemaDeDialogo : MonoBehaviour
{
    // patron SingleTon   ( Que hace)
    // asegura que esta sea la UNICA instancia de SistemaDialogo
    //  asegura que esa instncia sea accesible desde cualquier punto del programa 

    // una pregunta estatica no es una que no puedas cambiar , sino que ahce que pertenezca a la clase ( fabrica ) y no a las instancias de la clase ( productos)

    // referencia al gamobjectr marcos y cuando private void OnConnectedToServer()

    // inicie un dialogo 

    public static SistemaDeDialogo sistema;
    [SerializeField] GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;
    //[SerializeField] private Transform npcCamera;

    private bool escribiendo; // para saber si esta escribiendo o no
    private int indiceFraseActual;

    private DialogaSO dialogoActual;

    [SerializeField] DialogaSO dialogo;



    //private void Awake()
    //{
    //    // si el trono se queda vacio ...
    //    if (sistema == null)
    //    {
    //        // reclamo el trono y me lo quedo 
    //        sistema = this;

    //        // no me destruyo entre escenas
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void Awake()
    {
        IniciarDialogo();
    }

    public void IniciarDialogo()
    {
        
        //npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);

        Time.timeScale = 0;
        // el dialogo actual con el que trabajamos es el que me dan por parametro de entrada
        dialogoActual = dialogo;
        marcos.SetActive(true);
        StartCoroutine(EscribirFrase());

    }

    private IEnumerator EscribirFrase()
    {
        escribiendo = true;
        textoDialogo.text = "";

        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.tiempo);

            // espera
        }
        escribiendo = false;
    }

    public void SiguienteFrase()
    {
        if (escribiendo)
        {
            CompletarFrase();
            escribiendo = false;
        }
        else
        {
            // avanzo de indice de frase y si aun me quedan frases las escribo y si no 
            indiceFraseActual++;
            if (indiceFraseActual >= dialogoActual.frases.Length)
            {
                TerminarDialogo();
            }
            StartCoroutine(EscribirFrase());
        }

    }
    private void CompletarFrase()
    {
        StopAllCoroutines();
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
    }

    private void TerminarDialogo()
    {
        SceneManager.LoadScene(2);
        //marcos.SetActive(false);
        //StopAllCoroutines();
        //indiceFraseActual = 0; /// para reiniciar y volver a empezar 
        //dialogoActual = null; // ya no quedan dialogos hasta que me vuelvan a clicar
        Time.timeScale = 1f;
    }

}
