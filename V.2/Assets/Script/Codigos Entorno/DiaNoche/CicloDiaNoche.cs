using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    // Variable que determina la velocidad de rotacion del objeto. 
    public int escalaRotacion = 10; 

    void Update()
    {
        // Con esta linea de codigo se gira cierto objeto respecto a la variable velocidad en el eje x.
        transform.Rotate(escalaRotacion * Time.deltaTime, 0, 0); 
    }
}
