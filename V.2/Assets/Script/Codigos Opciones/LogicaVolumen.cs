using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogicaVolumen : MonoBehaviour {
    // Variables utilizadas. 
    // -- Deslizador para subir o bajar el volumen. 
    public Slider slider;
    // -- Valor númerico del deslizador. 
    public float sliderValue;
    // -- Imagen que se mostrará cuando el volumen sea 0. 
    public Image imageMute; 

    // Método que analiza las preferencias guardadas del deslizador y las pone al inicirse el juego nuevamente. 
    void Start() {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyEnSilencio(); 
    }

    // Método que analiza el valor númerico donde se quedó la última vez. 
    public void changeSlider(float valor) {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyEnSilencio();
    }

    // Si el deslizador está al mínimo y el valor númerico es 0, entonces muestra una imagen. 
    public void RevisarSiEstoyEnSilencio() {
        if(sliderValue == 0) {
            imageMute.enabled = true; 
        } else {
            imageMute.enabled = false; 
        }
    }
}
