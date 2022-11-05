using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorNotaPino : MonoBehaviour
{
    public GameObject notaVisualPino;
    public bool activa; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && activa == true)
        {
            notaVisualPino.SetActive(true); 
        }

        if (Input.GetKeyDown(KeyCode.Escape) && activa == true)
        {
            notaVisualPino.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activa = false;
            notaVisualPino.SetActive(false);
        }
    }
}
