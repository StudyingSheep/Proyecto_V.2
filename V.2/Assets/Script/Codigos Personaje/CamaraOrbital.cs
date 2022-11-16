using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraOrbital : MonoBehaviour
{
    private Vector2 angulo = new Vector2(90 * Mathf.Deg2Rad, 0);

    public float distancia;
    public Transform seguir;
    public Vector2 sensibilidad; 

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; 
    }
    void Update()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X");
        if (mouseHorizontal != 0)
        {
            angulo.x += mouseHorizontal * Mathf.Deg2Rad * sensibilidad.x; 
        }

        float mouseVertical = Input.GetAxis("Mouse Y");
        if (mouseVertical != 0)
        {
            angulo.y += mouseVertical * Mathf.Deg2Rad * sensibilidad.y;
            angulo.y = Mathf.Clamp(angulo.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad); 
        }
    }

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
