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

    // Variables para hacer que el personaje golpeé 
    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoGolpe = 10; 

    void Start() {
        puedoSaltar = false; 
        anim = GetComponent<Animator>();

        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
    }

    // Para generalizar los cuadros por segundo en cualquier computadora. 
    void FixedUpdate() {
        if (!estoyAtacando) {
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }

        if (avanzoSolo) {
            rb.velocity = transform.forward * impulsoGolpe; 
        }
    }
    void Update() {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0) && puedoSaltar && !estoyAtacando) {
            anim.SetTrigger("Golpeo");
            estoyAtacando = true; 
        }

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (puedoSaltar) {
            // Funciona con una ves que se presione la barra espaciadora 
            if (!estoyAtacando) {
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

    // Metodos para cuando el personaje golpea
    public void DejarDeGolpear() {
        estoyAtacando = false;
    }

    public void AvanzoSolo() {
        avanzoSolo = true; 
    }

    public void DejarDeAvanzar() {
        avanzoSolo = false; 
    }
}
