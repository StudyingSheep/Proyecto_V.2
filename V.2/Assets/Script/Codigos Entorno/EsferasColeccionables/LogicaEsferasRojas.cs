using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEsferasRojas : MonoBehaviour
{
    public LogicaNPC logicaNPC;

    // Cada vez que se recolecte con una esfera (chocando con ella)
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            logicaNPC.numDeObjetivos--;
            logicaNPC.textoMision.text = "Obtén las esferas" + "\nRestantes: " + logicaNPC.numDeObjetivos; 

            // Cuando se recolecten todas, entonces se acaba la mision
            if (logicaNPC.numDeObjetivos <= 0)
            {
                logicaNPC.textoMision.text = "¡Misión inicial completada!";
                logicaNPC.botonDeMision.SetActive(true); 
            }
            // Se desactivan las esferas
            transform.parent.gameObject.SetActive(false); 
        }
    }
}
