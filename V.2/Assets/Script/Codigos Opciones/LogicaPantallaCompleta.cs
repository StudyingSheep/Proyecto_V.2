using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class LogicaPantallaCompleta : MonoBehaviour {
    public Toggle toggle;
    // Variables utilizadas. 
    // -- Lista que guardará todas las resoluciones que nuestra computadora acepte. 
    public TMP_Dropdown resolucionesDropDown;
    // -- Vector que guardará todas las resoluciones posibles. 
    Resolution[] resoluciones; 

    // Método que verificará al inicio de cada inicio del juego como quedó la pantalla la última vez. 
    void Start() {
        if (Screen.fullScreen) {
            toggle.isOn = true;
        } else {
            toggle.isOn = false; 
        }
        // Además de saber si está en pantalla completa se guarda la resolución. 
        revisarResolucion(); 
    }

    // Método para activar o desactivar la pantalla completa. 
    public void activarPantallaCompleta(bool pantallaCompleta) {
        Screen.fullScreen = pantallaCompleta; 
    }

    // Para cambiar de resolución. 
    public void revisarResolucion() {
        resoluciones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0; 

        // Este ciclo va a guardar todas las resoluciones que encuentre que son compatibles con nuestra computadora. 
        // Las guardará como Alto x Ancho y la cantidad de hz. 
        for (int i = 0; i < resoluciones.Length; i++) {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height + " @ " + resoluciones[i].refreshRate + "hz";
            opciones.Add(opcion); 

            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && 
                resoluciones[i].height == Screen.currentResolution.height) {
                resolucionActual = i; 
            }
        }
        resolucionesDropDown.AddOptions(opciones);
        resolucionesDropDown.value = resolucionActual;
        resolucionesDropDown.RefreshShownValue();
 
    }

    // Método que utiliza el anterior para cambiar la resolución. 
    public void cambiarResolucion(int indiceResolucion) {
        
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen); 
    }
}