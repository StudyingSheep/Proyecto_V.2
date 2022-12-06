using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class LogicaBrillo : MonoBehaviour {
    // Variables utilizadas
    // -- Barra deslizadora para ajustar el brillo 
    public Slider slider;
    // -- Valor numerico de la barra deslizadora 
    public float sliderValue;
    // -- Imagen que aparece cuando el volumen esta en 0
    public Image panelBrillo; 
    
    void Start() {
        // Brillo que el usuario dejo la ultima vez que ajusto las opciones
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value); 
    }
    // Modificacion de los valores del brillo por el usuario
    public void changeSlider(float valor) {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);  
    }
}
