using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApretarBotones : MonoBehaviour
{
    private Animator animBoton;
    public Animator animPuerta;
    private bool EstaApretado = false;
    private bool CuboAfuera;
    private bool JugadorAfuera;
    private bool EstaApretadoJugador = false;
    private bool EstaApretadoCubo = false;

    public Collider col;

    // Start is called before the first frame update
    void Start()
    {

        animBoton = GetComponent<Animator>();
    }



    private void OnCollisionEnter(Collision other)
    {
        if (EstaApretado == false && other.gameObject.CompareTag("Cubo"))
        {
            EstaApretado = true;
            EstaApretadoCubo = true;
            animBoton.SetBool("ApretadoTrue", true);
            animPuerta.SetBool("BotonApretadoPuerta", true);
        }

        if (EstaApretado == false && other.gameObject.CompareTag("Player"))
        {
            EstaApretado = true;
            EstaApretadoJugador = true;
            animBoton.SetBool("ApretadoTrue", true);
            animPuerta.SetBool("BotonApretadoPuerta", true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Cubo") && EstaApretadoJugador == false)
        {
            EstaApretado = false;
            EstaApretadoCubo = false;
            animBoton.SetBool("ApretadoTrue", false);
            animPuerta.SetBool("BotonApretadoPuerta", false);
        }

        if (other.gameObject.CompareTag("Player") && EstaApretadoCubo == false)
        {
            EstaApretado = false;
            EstaApretadoJugador = false;
            animBoton.SetBool("ApretadoTrue", false);
            animPuerta.SetBool("BotonApretadoPuerta", false);
        }
    }

    private void Update()
    {
        //Debug.Log(EstaApretado);
        
    }

}

/**/