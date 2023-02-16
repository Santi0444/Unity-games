using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPortalGun : MonoBehaviour
{
    private Rigidbody rb;
    private Transform portalGun;
    public Transform PosicionOriginal;
    public Transform PosicionOriginalNivel2;
    public Transform PosicionOriginalNivel3;

    public Animator animacionIzquierdo;
    public Animator animacionDerecho;    
    public Animator animacionIzquierdo2;
    public Animator animacionDerecho2;
    public Animator animacionIzquierdo3;
    public Animator animacionDerecho3;
    private Animator PortalgunAnim;

    public GameObject electricidadDerecho;
    public GameObject electricidadIzquierdo;
    public GameObject electricidadDerecho2;
    public GameObject electricidadIzquierdo2;
    public GameObject electricidadDerecho3;
    public GameObject electricidadIzquierdo3;
    public GameObject SonidoLoop;
    public GameObject SonidoLoop2;
    public GameObject SonidoLoop3;

    public AudioSource prender;
    public AudioSource apagar;
    public AudioSource prender2;
    public AudioSource apagar2;
    public AudioSource prender3;
    public AudioSource apagar3;

    private bool puedeSonarLoop;
    private bool ponerkinematic;
    private bool ModoSpawneado;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        portalGun = gameObject.GetComponent<Transform>();   
        PortalgunAnim = gameObject.GetComponent<Animator>();

        electricidadDerecho.SetActive(false);
        electricidadIzquierdo.SetActive(false);
        electricidadDerecho2.SetActive(false);
        electricidadIzquierdo2.SetActive(false);
        electricidadDerecho3.SetActive(false);
        electricidadIzquierdo3.SetActive(false);

        SpawnPortalGun();
    }

    // Update is called once per frame
    void Update()
    {
        if (!prender.isPlaying && puedeSonarLoop)
        {
            //Debug.Log("Loop");
            SonidoLoop.SetActive(true);
            SonidoLoop2.SetActive(true);
            SonidoLoop3.SetActive(true);
        }
         
        else
        {
            SonidoLoop.SetActive(false);
            SonidoLoop2.SetActive(false);
            SonidoLoop3.SetActive(false);
        }

        if(ponerkinematic)
        {
            rb.isKinematic = false;
        }
    }

    public void SpawnPortalGun()
    {
        ModoSpawneado = true;
        ponerkinematic = false;
        SonidoLoop.SetActive(false);
        SonidoLoop2.SetActive(false);
        portalGun.transform.localScale = new Vector3(1, 1, 0.8f);
        animacionDerecho.SetBool("Spawnear", true);
        animacionIzquierdo.SetBool("Spawnear", true); 
        animacionDerecho2.SetBool("Spawnear", true);
        animacionIzquierdo2.SetBool("Spawnear", true);
        animacionDerecho3.SetBool("Spawnear", true);
        animacionIzquierdo3.SetBool("Spawnear", true);
        PortalgunAnim.SetBool("Spawnear", true);
        electricidadDerecho.SetActive(true);
        electricidadIzquierdo.SetActive(true);
        electricidadDerecho2.SetActive(true);
        electricidadIzquierdo2.SetActive(true);
        electricidadDerecho3.SetActive(true);
        electricidadIzquierdo3.SetActive(true);
        prender.Play();
        prender2.Play();
        prender3.Play();
        //Debug.Log("eoeoeoeoeoeo");
        puedeSonarLoop = true;

        if (portalGun.localScale == new Vector3(1, 1, 0.8f))
        {
            if (PosicionOriginal.gameObject.activeInHierarchy == false)
            {

                portalGun.position = PosicionOriginalNivel2.position;
                portalGun.rotation = PosicionOriginalNivel2.rotation;
                rb.isKinematic = true;
            }
            else
            {

                portalGun.position = PosicionOriginal.position;
                portalGun.rotation = PosicionOriginal.rotation;
                rb.isKinematic = true;
            }

            if (!PosicionOriginal.gameObject.activeInHierarchy && !PosicionOriginalNivel2.gameObject.activeInHierarchy)
            {

                portalGun.position = PosicionOriginalNivel3.position;
                portalGun.rotation = PosicionOriginalNivel3.rotation;
                rb.isKinematic = true;
            }
            Invoke("Falsear", 2);
        }
    }

    public void Falsear()
    {
        animacionDerecho.SetBool("Spawnear", false);
        animacionIzquierdo.SetBool("Spawnear", false);
        animacionDerecho2.SetBool("Spawnear", false);
        animacionIzquierdo2.SetBool("Spawnear", false);
        animacionDerecho3.SetBool("Spawnear", false);
        animacionIzquierdo3.SetBool("Spawnear", false);
        PortalgunAnim.SetBool("Spawnear", false);

        portalGun.transform.localScale = new Vector3(10.12415f, 10.85558f, 8.057501f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Pene");
        if (other.gameObject.CompareTag("Rompecubos") || other.gameObject.CompareTag("Rompecubos2"))
        {
            SpawnPortalGun();
            //Debug.Log("Pijaa");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("DesactivarKinematic"))
        {
            electricidadDerecho.SetActive(false);
            electricidadIzquierdo.SetActive(false);
            electricidadDerecho2.SetActive(false);
            electricidadIzquierdo2.SetActive(false);
            electricidadDerecho3.SetActive(false);
            electricidadIzquierdo3.SetActive(false);
            puedeSonarLoop = false;
            Debug.Log(ModoSpawneado);
            if(!puedeSonarLoop && ModoSpawneado)
            {
                apagar.Play();
                apagar2.Play();
                apagar3.Play();
                ModoSpawneado = false;
            }
            rb.isKinematic = false;
            
        }

        
    }

    public void RigidBodyOff()
    {
        //Debug.Log("Kinematic off");
        ponerkinematic = true;
    }
}
