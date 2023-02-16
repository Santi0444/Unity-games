using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertanv2 : MonoBehaviour
{
    public Animator puerta;
    public AudioSource puertaAbrir;
    public AudioSource puertaCerrar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "CentroJugador")
        {
            Debug.Log("toco");
            puertaAbrir.Play();
            puerta.SetBool("salio", false);
            puerta.SetBool("entro", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CentroJugador")
        {
            puertaCerrar.Play();
            puerta.SetBool("salio", true);
            puerta.SetBool("entro", false);
        }
    }

}
