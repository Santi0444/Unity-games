using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subeybajajugadorarriba : MonoBehaviour
{
   
    public Animator subebaja;
    public Transform subeBaja;
    public GameObject jugador;
    public Transform jugador2;
    private bool Played = true;
    public Activador boton;
    public bool debeBajar;
    public bool esNivel1;

    public AudioSource plataformaBajar;
    public AudioSource plataformaSubir;

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

        if (boton.fueActivado == true)
        {
            
            if (debeBajar)
            {
                Debug.Log("Baja pelotudo");
                subebaja.SetBool("sube", true);
                if (!plataformaBajar.isPlaying && Played)
                {
                    plataformaBajar.Play();
                    Played = false;
                }
                jugador.transform.SetParent(null);
            }
        }
        else
        {
            
            if (!plataformaBajar.isPlaying && !Played)
            {
                plataformaSubir.Play();
                Played = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && esNivel1 && !Played)
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
