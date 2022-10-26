using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Variables pára mover al personaje
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    // Variables para hacer que el personaje salte
    public Rigidbody rb;
    public float fuerzaDeSalto  = 8f;
    public bool puedoSaltar;

    // Variables para hacer que el personaje se agache
    public float velocidadInicial;
    public float velocidadAgachado;

    void Start() {
        puedoSaltar = false; 
        anim = GetComponent<Animator>();

        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
    }

    // Para generalizar los cuadros por segundo en cualquier computadora. 
    void FixedUpdate() {
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
    }
    void Update() {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (puedoSaltar) {
            // Funciona con una ves que se presione la barra espaciadora 
            if (Input.GetKeyDown(KeyCode.Space)) {
                anim.SetBool("Salto", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse); 
            }
            // Solo funciona mientras se presiona la tecla 
            if (Input.GetKey(KeyCode.LeftControl)) {
                anim.SetBool("Agacharse", true);
                velocidadMovimiento = velocidadAgachado; 
            } else {
                anim.SetBool("Agacharse", false);
                velocidadMovimiento = velocidadInicial;
            }

            anim.SetBool("TocarSuelo", true);
        } else {
            EstoyCayendo(); 
        }
    }

    // Método/Función que define el comportamiento al estar cayendo
    public void EstoyCayendo() {
        anim.SetBool("TocarSuelo", false);
        anim.SetBool("Salto", false);
    }
}
