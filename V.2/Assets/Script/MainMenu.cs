 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    // Metodos para moverse entre escenas, estos son los botones del menu principal 
    public void escenaNiveles() {
        SceneManager.LoadScene("Niveles"); 
    }

    public void escenaOpciones() {
        SceneManager.LoadScene("Opciones");
    }

    public void salirJuego() {
        Application.Quit(); 
    }
}
