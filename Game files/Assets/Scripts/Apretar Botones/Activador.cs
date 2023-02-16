using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    private Animator animBoton;
    public Animator animador;
    public bool fueActivado;
    public string VariableAnimador;
    private bool reprodujoCerrar = true;
    private bool reprodujoAbrir;
    public bool EnableSonido;

    public AudioSource plataformaSubir;
    public AudioSource plataformaBajar;
    private int contador = 0;

    public AudioSource SonidoAbrir;
    public AudioSource SonidoCerrar;
    // Start is called before the first frame update
    void Start()
    {
        animBoton = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 0)
        {
            fueActivado = false;
            animBoton.SetBool("ApretadoTrue", false);
            animador.SetBool(VariableAnimador, false);
            //plataformaBajar.Play();
            reprodujoAbrir = false;
            if (EnableSonido && !reprodujoCerrar && !SonidoCerrar.isPlaying)
            {
                Debug.Log("No debe sonar esto ahora");
                SonidoCerrar.Play();
                reprodujoCerrar = true;

            }
        }


        if(contador >= 1)
        {
            fueActivado = true;
            animBoton.SetBool("ApretadoTrue", true);
            reprodujoCerrar = false;
            if (EnableSonido && !reprodujoAbrir && !SonidoAbrir.isPlaying)
            {
                SonidoAbrir.Play();
                reprodujoAbrir = true;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //empiezaAccion = true;
            contador += 1;
            animador.SetBool(VariableAnimador, true);
            

        }

        if (collision.gameObject.CompareTag("Cubo"))
        {
            //empiezaAccion = true;
            contador += 1;
            animador.SetBool(VariableAnimador, true);
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            contador -= 1;
            

        }

        if (collision.gameObject.CompareTag("Cubo"))
        {
            contador -= 1;
            
        }
    }


}
