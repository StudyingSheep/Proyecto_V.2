using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public PlayerMove logicaPersonaje; 
    void Start() {
        
    }


    void Update() {
        
    }

    private void OnTriggerStay(Collider other) {
        logicaPersonaje.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other) {
        logicaPersonaje.puedoSaltar = false;
    }
}
