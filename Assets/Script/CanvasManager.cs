using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    private bool pausa;
    [SerializeField] GameObject menuPausa;
   
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
}
