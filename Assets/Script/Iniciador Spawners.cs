using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciadorSpawners : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            Debug.Log("ESTA ENTRANDO ; TODOS A SU POSICION");
            spawner.SetActive(true);

        }
    }
}
