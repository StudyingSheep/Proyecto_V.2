using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles : MonoBehaviour
{
    // Metodos para moverse a los niveles
    public void nivelUno() {
        SceneManager.LoadScene("Mapa");
    }
}
