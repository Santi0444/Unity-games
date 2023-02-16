using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirJugador : MonoBehaviour
{
    public Transform Jugador;
    public Transform PosicionInicial;
    public Transform PosicionInicial2;
    public Transform PosicionInicial3;
    public Camera CamaraJugador;
    // Start is called before the first frame update
    void Start()
    {
       if(ButtonInteraction.NivelActual == 1)
       {
            Jugador.transform.position = PosicionInicial.transform.position;
       }
       
       else if (ButtonInteraction.NivelActual == 2)
       {
            Jugador.transform.position = PosicionInicial2.transform.position;
       }

       else if (ButtonInteraction.NivelActual == 3)
       {
            Jugador.transform.position = PosicionInicial3.transform.position;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rompecubos" || other.gameObject.tag == "BolaEnergia")
        {
            if (PosicionInicial.gameObject.activeInHierarchy)
            {
                Jugador.transform.position = PosicionInicial.transform.position;
            }
            
            else if(PosicionInicial2.gameObject.activeInHierarchy && !PosicionInicial.gameObject.activeInHierarchy)
            {
                Jugador.transform.position = PosicionInicial2.transform.position;
            }

            else if (!PosicionInicial2.gameObject.activeInHierarchy && !PosicionInicial.gameObject.activeInHierarchy)
            {
                Jugador.transform.position = PosicionInicial3.transform.position;
            }
        }
        if (other.gameObject.tag == "Rompecubos2")
        {

            Jugador.transform.position = PosicionInicial3.transform.position;
        }
    }


}
