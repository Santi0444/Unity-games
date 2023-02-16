using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorNivel3 : MonoBehaviour
{
    private Animator animBoton;
    public bool fueActivado;

    private int contador = 0;
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
        }


        if (contador >= 1)
        {
            fueActivado = true;
            animBoton.SetBool("ApretadoTrue", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            contador += 1;
        }

        if (collision.gameObject.CompareTag("Cubo"))
        {
            contador += 1;
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
