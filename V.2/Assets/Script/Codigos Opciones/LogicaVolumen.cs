using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogicaVolumen : MonoBehaviour {
    // Variables utilizadas. 
    // -- Deslizador para subir o bajar el volumen. 
    public Slider slider;
    // -- Valor n�merico del deslizador. 
    public float sliderValue;
    // -- Imagen que se mostrar� cuando el volumen sea 0. 
    public Image imageMute; 

    // M�todo que analiza las preferencias guardadas del deslizador y las pone al inicirse el juego nuevamente. 
    void Start() {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyEnSilencio(); 
    }

    // M�todo que analiza el valor n�merico donde se qued� la �ltima vez. 
    public void changeSlider(float valor) {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyEnSilencio();
    }

    // Si el deslizador est� al m�nimo y el valor n�merico es 0, entonces muestra una imagen. 
    public void RevisarSiEstoyEnSilencio() {
        if(sliderValue == 0) {
            imageMute.enabled = true; 
        } else {
            imageMute.enabled = false; 
        }
    }
}
