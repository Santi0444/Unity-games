using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ButtonInteraction : MonoBehaviour
{
    public GameObject MenuNiveles;
    public GameObject MenuPrincipal;
    public GameObject MenuOpciones;
    public GameObject Boton;
    public static int NivelActual = 0;
    private void Start()
    {
        
    }

    public void ComenzarNivel1()
    {
        SceneManager.LoadScene("Nivel 1");
        NivelActual = 1;

    }
    public void ComenzarNivel2()
    {
        SceneManager.LoadScene("Nivel 1");
        NivelActual = 2;
    }
    
    public void ComenzarNivel3()
    {
        SceneManager.LoadScene("Nivel 1");
        NivelActual = 3;
    }

    public void PasarAniveles()
    {
        MenuNiveles.SetActive(true);
        MenuPrincipal.SetActive(false);
    }
    public void Volver()
    {
        MenuNiveles.SetActive(false);
        //Boton.SetActive(false);
        MenuPrincipal.SetActive(true);
        MenuOpciones.SetActive(false);

    }
    public void Opciones()
    {
        MenuPrincipal.SetActive(false);
        MenuOpciones.SetActive(true);

    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("IntroUI");
        NivelActual = 0;
    }
}
