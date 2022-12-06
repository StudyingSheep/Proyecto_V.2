using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class LogicaObjetivosEsferas : MonoBehaviour
{
    // Variables utilizadas con su descripción. 
    public int numeroObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonMision;

    void Start()
    {
        // El numero de objetivos será igual a la cantidad de esferas que se detecte que hay en el mapa. 
        numeroObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Obtén las esferas" + "\nRestantes: " + numeroObjetivos; 
    }

    // Cada vez que se haga una interacción con una esfera sucedera lo siguiente
    void OnTriggerEnter(Collider col)
    {
        // Si se hace una colision con el objeto con el tag "objetivo" (las esferas) entonces...
        if (col.gameObject.tag == "objetivo")
        {
            // Se destruira la esfera
            Destroy(col.transform.parent.gameObject);
            // Los objetivos se reduciran
            numeroObjetivos--; 
            textoMision.text = "Obtén las esferas" + "\nRestantes: " + numeroObjetivos;
            // Cuando la cantidad de objetivos sea igual o menor a cero se complara la mision 
            if (numeroObjetivos <= 0)
            {
                textoMision.text = "¡Misión inicial completada!";
                botonMision.SetActive(true); 
            }
        }

    }
}
