using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubeybajaNivel2 : MonoBehaviour
{
   
    public Animator subebaja;
    public Transform subeBaja;
    public GameObject jugador;
    public Transform jugador2;
    public bool debeBajar;
    private bool Played = true;
    public AudioSource plataformaBajar;
    public AudioSource plataformaSubir;

    public Boladeenergiamovimiento sostenedor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(jugador.transform.position.y < subeBaja.transform.position.y)
        {
            debeBajar = true;
        }

        else
        {
            debeBajar = false;
        }

        if (sostenedor.fueActivado == true)
        {
            
            if (debeBajar)
            {
                Debug.Log("Baja pelotudo");
                subebaja.SetBool("sube", true);
                if(!plataformaBajar.isPlaying && Played)
                {
                    plataformaBajar.Play();
                    Played = false;
                }
                jugador.transform.SetParent(null);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!subebaja.GetBool("sube")) 
            {
                Debug.Log("La concha de tu hermana");
            }
            subebaja.SetBool("sube", false);
            Played = true;
            plataformaSubir.Play();
            jugador.transform.SetParent(subeBaja);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (debeBajar)
            {
                
                jugador.transform.SetParent(null);
            }
        }
    }
}
