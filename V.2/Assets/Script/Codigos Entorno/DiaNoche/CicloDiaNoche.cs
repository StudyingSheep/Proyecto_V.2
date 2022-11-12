using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{

    public int escalaRotacion = 10; 

    void Update()
    {
        transform.Rotate(escalaRotacion * Time.deltaTime, 0, 0); 
    }
}
