using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public PlayerMove logicaPersonaje; 

    // Metodos que detectan las colisiones entre la capsula puesta en los pies del jugador y el piso. 
    private void OnTriggerStay(Collider other) {
        if (other.tag == "Piso")
        {
            logicaPersonaje.puedoSaltar = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        logicaPersonaje.puedoSaltar = false;
    }
}