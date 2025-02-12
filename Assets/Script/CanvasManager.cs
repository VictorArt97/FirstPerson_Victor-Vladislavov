using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    private bool pausa;
    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject instrucciones;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (pausa == false)
            {
                pausa = true;
                menuPausa.SetActive(true);
               
                Time.timeScale = 0f;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
        }
        
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        pausa = false;

        Time.timeScale = 1;
        Cursor.visible=false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void DeathScreen()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void VolverAlEscritorio()
    {
        SceneManager.LoadScene(0);
    }
    public void DesactivarInstrucciones()
    {
        instrucciones.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
