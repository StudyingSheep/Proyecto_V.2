using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorNotas : MonoBehaviour
{
    // Variables utilizadas
    public GameObject notaVisual;
    public bool activa;
    public GameObject panelInteraccion; 

    // Update is called once per frame
    void Update()
    {
        // Cada vez que se este cerca de una nota y se presione la letra "E" aparecera el canvas en pantalla
        if (Input.GetKeyDown(KeyCode.E) && activa == true)
        {
            notaVisual.SetActive(true);
            panelInteraccion.SetActive(false);

        }
        // Cada vez que se este viendo la nota y se presione la tecla "Escape" desaparecera el canvas de la pantalla
        if (Input.GetKeyDown(KeyCode.Escape) && activa == true)
        {
            notaVisual.SetActive(false);
        }
    }
    // Si se esta cerca de la nota, entonces se activa el poder interactuar con la nota 
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activa = true;
            panelInteraccion.SetActive(true); 
        }
    }
    // Si el jugador se aleja de la nota, entonces se desactivara el poder interactuar con la nota 
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activa = false;
            notaVisual.SetActive(false);
            panelInteraccion.SetActive(false); 
        }
    }
}