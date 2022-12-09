using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaNPCDialogos : MonoBehaviour
{
    public GameObject panelDialogo;
    public bool activa;
    public GameObject panelInteraccion;

    void Update()
    {
        // Cada vez que se este cerca de un NPC y se presione la letra "E" aparecera el canvas en pantalla
        if (Input.GetKeyDown(KeyCode.E) && activa == true)
        {
            panelDialogo.SetActive(true);
            panelInteraccion.SetActive(false);
        }
        // Cada vez que se este interactuando y se presione la tecla "Escape" desaparecera el canvas de la pantalla
        if (Input.GetKeyDown(KeyCode.Escape) && activa == true)
        {
            panelDialogo.SetActive(false);
        }
    }

    // Si se esta cerca del NPC, entonces se activa el poder interactuar con la nota 
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activa = true;
            panelInteraccion.SetActive(true);
        }
    }
    // Si el jugador se aleja del NPC, entonces se desactivara el poder interactuar con el NPC
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activa = false;
            panelDialogo.SetActive(false);
            panelInteraccion.SetActive(false);
        }
    }
}

