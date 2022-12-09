using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro; 

public class LogicaNPC : MonoBehaviour
{
    // Variables utilizadas
    public GameObject simboloMision;
    public PlayerMove jugador;
    // -- Paneles que van a aparecer y desaparecer conforme se requiera
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    // Vector que contiene los objetivos
    public GameObject[] objetivos;
    public int numDeObjetivos;
    public GameObject botonDeMision;

    // Opciones ejecutadas al iniciar el juego. 
    void Start()
    {
        numDeObjetivos = objetivos.Length;
        textoMision.text = "Obtén las esferas" + "\nRestantes: " + numDeObjetivos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        simboloMision.SetActive(true);
        panelNPC.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && aceptarMision == false && jugador.puedoSaltar == true)
        {
            // Estas lineas hacen que al interactuar con el NPC nuestro personaje se ubique de frente a el y no se pueda mover mientras haya interaccion. 
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);

            jugador.anim.SetFloat("VelX", 0);
            jugador.anim.SetFloat("VelY", 0);
            jugador.enabled = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true); 
        }
    }

    // Lo que sucede cuando el jugador se acerca al NPC
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true;
            if (aceptarMision == false)
            {
                panelNPC.SetActive(true); 
            }
        }
    }

    // Lo que sucede cuando el jugador se aleja del NPC 
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;

            panelNPC.SetActive(false);
            panelNPC2.SetActive(false); 
        }
    }

    // Cuando el jugador presiona el boton de no aceptar la mision
    public void No()
    {
        jugador.enabled = true;
        panelNPC2.SetActive(false);
        panelNPC.SetActive(true); 
    }

    // Cuando el jugador presiona el boton de si aceptar la mision
    public void Si()
    {
        jugador.enabled = true;
        aceptarMision = true;
        // Un ciclo que va activando las esferas. 
        for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }
        // Una vez aceptada y completada la misión una vez, ya no se podra hacer nuevamente
        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true);
    }
}