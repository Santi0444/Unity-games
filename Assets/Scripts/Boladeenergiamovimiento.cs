using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boladeenergiamovimiento : MonoBehaviour
{
    public float velocidadbola;
    public Transform bola;
    private Rigidbody Bola;
    int i = 0;
    public Instanciabolaenergia instancia;
    public Instanciabolaenergia Timer;
    public Animator subebaja;
    public Transform OutDirAzul;
    public Transform OutDirNaranja;
    public Transform instanciador;
    public bool tocounavez;
    public bool esNivel2;
    public Animator tirador;
    //public Instanciacubo Cubospawner;

    public GameObject colliderPata;

    public AudioSource spawnerAbrir;
    public AudioSource plataformaBajar;
    public AudioSource plataformaSubir;
    public bool fueActivado;
    // Start is called before the first frame update
    void Start()
    {
        //instancia = GetComponent<Instanciabolaenergia>();
        //Timer = GetComponent<Instanciabolaenergia>();
        Bola = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(i);
        bola.transform.Translate(Vector3.forward * velocidadbola * Time.deltaTime); 
        Bola.velocity = Vector3.zero;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Posible") || collision.gameObject.CompareTag("PisoNoPortal") || collision.gameObject.CompareTag("TiradorEnergia"))
        {
            //Debug.Log("Toco algo pedazo de puto");
            colliderPata.SetActive(true);
            i++;
            bola.transform.forward = -bola.transform.forward;
        }
        
        if (collision.gameObject.tag == "sostenedorbola")
        {
            velocidadbola = 0;
            if (esNivel2)
            {
                plataformaBajar.Play();
                subebaja.SetBool("sube", true);
            }

            else
            {
                plataformaSubir.Play();
                subebaja.SetBool("sube", false);
            }
            fueActivado = true;
            //Cubospawner.Spawnear = false;
        }

        if (collision.gameObject.tag == "sostenedorbola2")
        {
            velocidadbola = 0;
            plataformaBajar.Play();
            subebaja.SetBool("sube", true);
            fueActivado = true;
            //Cubospawner.Spawnear = false;
        }

        if (i > 3)
        {
            
            bola.transform.position = new Vector3(555, 0, 0);
            tocounavez = true;
            colliderPata.SetActive(false);
            Invoke("Tirarbola", 3);
            
            i = 0;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PortalAzul"))
        {
            
            bola.transform.forward = OutDirAzul.forward;
            
        }
        if (other.gameObject.CompareTag("PortalNaranja"))
        {
            
            bola.transform.forward = OutDirNaranja.forward;
           
        }
    }
    
    public void Tirarbola()
    {
        if (tocounavez == true)
        {
            colliderPata.SetActive(false);
            tirador.SetBool("Tirobola", true);
            spawnerAbrir.Play();
            bola.transform.position = instanciador.transform.position;
            bola.transform.rotation = instanciador.transform.rotation;
            tocounavez = false;

        }
    }

}
