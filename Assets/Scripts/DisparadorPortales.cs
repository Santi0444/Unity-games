using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


public class DisparadorPortales : MonoBehaviour
{
    public Transform portalAzul;
    public Transform portalNaranja;
    public Collider portalAzulcollider;
    public Collider portalNaranjacollider;
    public Transform firePoint;
    public bool esAzul = true;
    Renderer rend;
    public InputActionReference ToggleReference;
    public InputActionReference ToggleReference2;


    public cambiarLayer cambiador;
    public cambiarLayer cambiador2;
    public GameObject PortalGun;
    public Material MaterialNaranja;
    public Material MaterialAzul;
    public LayerMask Posible;

    [System.Obsolete]
    private XRInteractableEvent interactable;

    public bool SeDisparoPortal = false;
    public bool SeDisparoPortalNaranja = false;

    //public Collider colliderCubo;

    public Transform plataforma;
    public Transform plataformaSube;

    public Transform posicionAgarrePistola;

    public Transform cubo;
    public Rigidbody rbCubo;
    public Transform cubo2;
    public Rigidbody rbCubo2;
    private GameObject CuboAgarrar;
    private TeleportEnabler CuboAgarrarEnabler;

    public GameObject Electricidad;

    private bool ObjetoAgarrado;
    public bool AgarroCubo;
    public bool AgarroCubo2;
    private bool puedeAgarrarCubo;
    private bool puedeAgarrarCubo2;

    public AudioSource AgarrarPrender;
    public AudioSource AgarrarApagar;
    public GameObject AgarrarLoop;

    private Vector3 WorldScale;

    RaycastHit hit;

    private void Awake()
    {
        ToggleReference.action.started += ToggleA;
        ToggleReference2.action.started += ToggleB;
        
    }

    void Start()
    {
        cambiador = GameObject.FindGameObjectWithTag("CambiadorLayerNaranja").GetComponent<cambiarLayer>();
        cambiador2 = GameObject.FindGameObjectWithTag("CambiadorLayerAzul").GetComponent<cambiarLayer>();
        //colCubo = GameObject.FindGameObjectWithTag("AgarrarCubo").GetComponent<Collider>();
        //plataforma = GameObject.Find("ParentPlataforma").GetComponent<Transform>();
        rend = GetComponent<Renderer>();
        SeDisparoPortal = false;
        SeDisparoPortalNaranja = false;
    }

    private void OnEnable()
    {
       
    }

    void FixedUpdate()

    {
        //if (plataforma.transform.position.y < -4.1f)
        //{
        //    portalAzul.transform.SetParent(null);

        //} 
        //if (plataforma.transform.position.y < -4.1f)
        //{
        //    portalNaranja.transform.SetParent(null);

        //}
        if (!SeDisparoPortal && SeDisparoPortalNaranja)
        {
            portalAzulcollider.enabled = false;
            portalNaranjacollider.enabled = false;
            cambiador.enabled = false;
            cambiador2.enabled = false;

        }
        else if (SeDisparoPortal && !SeDisparoPortalNaranja)
        {
            portalAzulcollider.enabled = false;
            portalNaranjacollider.enabled = false;
            cambiador.enabled = false;
            cambiador2.enabled = false;
        }

        else
        {
            portalAzulcollider.enabled = true;
            portalNaranjacollider.enabled = true;
            cambiador.enabled = true;
            cambiador2.enabled = true;
        }

        if (esAzul == false)
        {
            Material[] Mat;
            Mat = rend.materials;
            Mat[2] = MaterialNaranja;
            Mat[3] = MaterialNaranja;
            Mat[4] = MaterialNaranja;
            Mat[6] = MaterialNaranja;
            rend.materials = Mat;
            
        }
        else
        {
            Material[] Mat;
            Mat = rend.materials;
            Mat[2] = MaterialAzul;
            Mat[3] = MaterialAzul;
            Mat[4] = MaterialAzul;
            Mat[6] = MaterialAzul;
            rend.materials = Mat;
          

        }

        /*if (SeDisparoPortal == true)
        {
            Vector3 target = firePoint.forward;
            Vector3 firePointPosition = firePoint.position;
            RaycastHit hit;
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, Posible))
            {
                ponerPortal(hit.point);
            }
        }
        */

        //Debug.Log(puedeAgarrarCubo2);
        if (AgarroCubo)
        {
            //cubo.transform.SetParent(Padree);
            //cubo.localScale = WorldScale;

            CuboAgarrar.transform.position = posicionAgarrePistola.position;
            CuboAgarrar.transform.Rotate(2, 0.5f, 2);
            if (!AgarrarPrender.isPlaying)
            {
                AgarrarLoop.SetActive(true);
            }

        }

        //if (AgarroCubo2)
        //{
        //    cubo2.transform.position = Vector3.MoveTowards(cubo2.transform.position, posicionAgarrePistola.position, 0.07f);
        //    CuboAgarrar.transform.Rotate(2, 0.5f, 2);
        //    if (!AgarrarPrender.isPlaying)
        //    {
        //        AgarrarLoop.SetActive(true);
        //    }

        //}
    }



    public void MoverPortal()
    {

        Vector3 target = firePoint.forward;
        Vector3 firePointPosition = firePoint.position;
        RaycastHit hit;

            

            if (esAzul == true && Physics.Raycast(firePoint.position, firePoint.forward, out hit, Posible) && (hit.collider.CompareTag("Posible") || hit.collider.CompareTag("Piso")))
            {
                
                portalAzul.transform.position = hit.point;
                portalAzul.transform.rotation = hit.collider.transform.rotation;
                portalAzul.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                if (hit.transform.Equals(plataforma))
                {
                    
                    
                    
                    portalAzul.transform.SetParent(plataforma);
                    Debug.Log("Toco plataforma nivel3");

                }
                else
                {

                    portalAzul.transform.SetParent(null);
                    portalAzul.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

                }
                FindObjectOfType<AudioManagerr>().Play("PortalAzul");
                SeDisparoPortal = true;
               

            
                    //Debug.Log(hit.transform.name);
                }

            if (esAzul == false && Physics.Raycast(firePoint.position, firePoint.forward, out hit) && (hit.collider.CompareTag("Posible")))
            {
               
                portalNaranja.transform.position = hit.point;
                portalNaranja.transform.rotation = hit.collider.transform.rotation;
                portalNaranja.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                if (hit.transform.Equals(plataforma))
                {
                    Debug.Log("Cambiar posicion portal");
                    portalNaranja.transform.SetParent(plataforma);

                }
                else
                {

                    portalNaranja.transform.SetParent(null);
                    portalNaranja.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

                }
                FindObjectOfType<AudioManagerr>().Play("PortalNaranja");
                SeDisparoPortalNaranja = true;
                
                Debug.Log(hit.transform.name);
                
                
        }
        
           

    }


    public void Agarro()
    {
        ObjetoAgarrado = true;
    }

    public void Solto()
    {
        ObjetoAgarrado = false;
    }


    private void ToggleA(InputAction.CallbackContext context)
    {
        
        if (ObjetoAgarrado == true)
        {
            if (esAzul == false)
            {
                esAzul = true;

            }
            else
            {
                if (esAzul == true)
                {
                    esAzul = false;
                }
            }

            if (esAzul == false)
            {
                Material[] Mat;
                Mat = rend.materials;
                Mat[2] = MaterialNaranja;
                Mat[3] = MaterialNaranja;
                Mat[4] = MaterialNaranja;
                Mat[6] = MaterialNaranja;
                rend.materials = Mat;

            }
            else
            {
                Material[] Mat;
                Mat = rend.materials;
                Mat[2] = MaterialAzul;
                Mat[3] = MaterialAzul;
                Mat[4] = MaterialAzul;
                Mat[6] = MaterialAzul;
                rend.materials = Mat;


            }

        }
    }

    private void ToggleB(InputAction.CallbackContext context)
    {

        ApretoBotonAgarre();
        Debug.Log(CuboAgarrar.name);
        //if (ObjetoAgarrado)
        //{
        //    if(!AgarroCubo)
        //    {
        //        if (puedeAgarrarCubo)
        //        {
        //            AgarroCubo = true;
                    
        //            rbCubo.useGravity = false;
        //            rbCubo.constraints = RigidbodyConstraints.FreezePosition;
        //            AgarrarPrender.Play();
                    
        //            Electricidad.SetActive(true);
        //        }
                
        //    } 

        //    else
        //    {
        //        AgarroCubo = false;
        //        rbCubo.useGravity = true;
        //        rbCubo.constraints = RigidbodyConstraints.None;
        //        AgarrarLoop.SetActive(false);
        //        AgarrarApagar.Play();
        //        Invoke("EsperarTiempoDestruir", 0.7f);
        //    }



        //}

        //if (ObjetoAgarrado)
        //{
        //    if (!AgarroCubo2)
        //    {
        //        if (puedeAgarrarCubo2)
        //        {
        //            AgarroCubo2 = true;
        //            rbCubo2.useGravity = false;
        //            rbCubo2.constraints = RigidbodyConstraints.FreezePosition;
        //            AgarrarPrender.Play();
        //            Electricidad.SetActive(true);
        //        }

        //    }

        //    else
        //    {
        //        if (AgarroCubo2)
        //        {
        //            AgarroCubo2 = false;
        //            rbCubo2.useGravity = true;
        //            rbCubo2.constraints = RigidbodyConstraints.None;
        //            AgarrarLoop.SetActive(false);
        //            AgarrarApagar.Play();
        //            Invoke("EsperarTiempoDestruir", 0.7f);
        //        }
        //    }



        //}






    }

    public void ApretoBotonAgarre()
    {
        if (CuboAgarrar != null)
        {
            if (ObjetoAgarrado)
            {
                if (!AgarroCubo)
                {
                    if (puedeAgarrarCubo)
                    {
                        Debug.Log("Apreto boton");
                        CuboAgarrarEnabler.PuedeTeleportarse = false;
                        AgarroCubo = true;

                        CuboAgarrar.GetComponent<Rigidbody>().useGravity = false;
                        CuboAgarrar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                        AgarrarPrender.Play();
                        Electricidad.SetActive(true);
                    }

                }

                else
                {
                    CuboAgarrarEnabler.PuedeTeleportarse = true;
                    AgarroCubo = false;
                    CuboAgarrar.GetComponent<Rigidbody>().useGravity = true;
                    CuboAgarrar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    AgarrarLoop.SetActive(false);
                    AgarrarApagar.Play();
                    Invoke("EsperarTiempoDestruir", 0.7f);
                }



            }
        }

        //if (ObjetoAgarrado)
        //{
        //    if (!AgarroCubo2)
        //    {
        //        if (puedeAgarrarCubo2)
        //        {
        //            AgarroCubo2 = true;
        //            rbCubo2.useGravity = false;
        //            rbCubo2.constraints = RigidbodyConstraints.FreezePosition;
        //            AgarrarPrender.Play();
        //            Electricidad.SetActive(true);
        //        }

        //    }

        //    else
        //    {
        //        if (AgarroCubo2)
        //        {
        //            AgarroCubo2 = false;
        //            rbCubo2.useGravity = true;
        //            rbCubo2.constraints = RigidbodyConstraints.None;
        //            AgarrarLoop.SetActive(false);
        //            AgarrarApagar.Play();
        //            Invoke("EsperarTiempoDestruir", 0.7f);
        //        }
        //    }



        //}

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cubo"))
        {
            CuboAgarrar = other.gameObject;
            CuboAgarrarEnabler = CuboAgarrar.GetComponent<TeleportEnabler>();
            puedeAgarrarCubo = true;
        }

        //Debug.Log(CuboAgarrar.name);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cubo"))
        {
            CuboAgarrar = null;
            puedeAgarrarCubo = false;
        }
        //Debug.Log(CuboAgarrar.name);

    }

    private void EsperarTiempoDestruir()
    {
        Electricidad.SetActive(false);
    }
}
