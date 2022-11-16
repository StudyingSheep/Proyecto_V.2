using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class LogicaObjetivosEsferas : MonoBehaviour
{
    public int numeroObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonMision;

    void Start()
    {
        numeroObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Obtén las esferas" + "\nRestantes: " + numeroObjetivos; 
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "objetivo")
        {
            Destroy(col.transform.parent.gameObject);
            numeroObjetivos--; 
            textoMision.text = "Obtén las esferas" + "\nRestantes: " + numeroObjetivos;

            if (numeroObjetivos <= 0)
            {
                textoMision.text = "¡Misión inicial completada!";
                botonMision.SetActive(true); 
            }
        }

    }
}
