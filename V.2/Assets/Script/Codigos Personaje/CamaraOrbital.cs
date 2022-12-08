using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraOrbital : MonoBehaviour
{
    // Variables utilizadas. 
    // -- Angulo inicial de la camara. Detras del jugador. 
    private Vector2 angulo = new Vector2(90 * Mathf.Deg2Rad, 0);
    // Distancia entre la camara y el jugador. 
    public float distancia;
    // Esta variable ayuda a que la camra siga la posicion del jugador. 
    public Transform seguir;
    // Variable que permite aumentar o disminuir la sensibilidad de movimiento de la camara. 
    public Vector2 sensibilidad; 

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; 
    }
    // Metodo que actualiza y permite mover la camara. 
    void Update()
    {
        // De forma horizontal. 
        float mouseHorizontal = Input.GetAxis("Mouse X");
        if (mouseHorizontal != 0)
        {
            angulo.x += mouseHorizontal * Mathf.Deg2Rad * sensibilidad.x; 
        }
        // De dorma vertical. 
        float mouseVertical = Input.GetAxis("Mouse Y");
        if (mouseVertical != 0)
        {
            angulo.y += mouseVertical * Mathf.Deg2Rad * sensibilidad.y;
            angulo.y = Mathf.Clamp(angulo.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad); 
        }
    }

    // Metodo que permite mover la camara cuando no sea horizontal o vertical, sino en todas direcciones (por eso el uso de senos y cosenos)
    public void LateUpdate()
    {
        Vector3 orbita = new Vector3(
            Mathf.Cos(angulo.x) * Mathf.Cos(angulo.y),
            -Mathf.Sin(angulo.y), 
            -Mathf.Sin(angulo.x) * Mathf.Cos(angulo.y)
            );
        transform.position = seguir.position + orbita * distancia;
        transform.rotation = Quaternion.LookRotation(seguir.position - transform.position);
    }
}
