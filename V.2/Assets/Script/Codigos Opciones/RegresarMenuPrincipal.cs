using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarMenuPrincipal : MonoBehaviour
{
    // Método para cambiar entre pantallas. 
    public void regresarMenuPrincipal() {
        SceneManager.LoadScene("MainMenu");
    }
}
