using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class LogicaCalidad : MonoBehaviour {
    // Variables utilizadas 
    public TMP_Dropdown dropdown;
    public int calidad; 

    // Cuando se inicie el juego nuevamente se tendra la configuracion que el usuario dejo
    void Start() {
        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);
        dropdown.value = calidad;
        ajustarCalidad();
    }

    // Este metodo toma las opciones que te da Unity en cuanto a calidad y las ajusta con la ayuda de una lista que detecta automaticamente
    public void ajustarCalidad() {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        calidad = dropdown.value; 
    }
}