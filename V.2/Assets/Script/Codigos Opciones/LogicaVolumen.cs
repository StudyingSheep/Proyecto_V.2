using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogicaVolumen : MonoBehaviour {

    public Slider slider;
    public float sliderValue;
    public Image imageMute; 
    void Start() {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyEnSilencio(); 
    }
    public void changeSlider(float valor) {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyEnSilencio();
    }

    public void RevisarSiEstoyEnSilencio() {
        if(sliderValue == 0) {
            imageMute.enabled = true; 
        } else {
            imageMute.enabled = false; 
        }
    }
}
