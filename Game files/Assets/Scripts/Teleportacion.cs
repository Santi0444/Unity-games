using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleportacion : MonoBehaviour
{
    [SerializeField]
    public Transform portalDestino;
    private Rigidbody cubo;
    public Rigidbody portalGunVel;
    public float maxVelocidadPortal;
    private Transform portalAzul;
    private Transform portalNaranja;
    public Instanciacubo instanciador;
    public Instanciacubo instanciador2;
    public AudioSource PortalEnterAzul;
    public AudioSource PortalEnterAzul2;
    public AudioSource PortalEnterNaranja;

    public bool esAzul;

    // Start is called before the first frame update
    void Start()
    {
        cubo = GameObject.FindGameObjectWithTag("Cubo").GetComponent<Rigidbody>();
        
        portalAzul = GameObject.FindGameObjectWithTag("PortalAzul").GetComponent<Transform>();
        portalNaranja = GameObject.FindGameObjectWithTag("PortalNaranja").GetComponent<Transform>();
        //instanciador = GameObject.FindGameObjectWithTag("CuboSpawner").GetComponent<Instanciacubo>();
    }


   
    void OnTriggerEnter(Collider other)
    {
        if (EsTeleportable()) //&& TieneLaDistanciaNecesaria())

        {
            int random = Random.Range(0, 2);
            TeleportEnabler teleportEnabler = other.GetComponent<TeleportEnabler>();

            if (teleportEnabler.PuedeTeleportarse)
            {
                
                Teleportar(other);
                if (esAzul)
                {

                    if (random == 0)
                    {
                        PortalEnterAzul.Play();
                    }
                    else
                    {
                        PortalEnterAzul2.Play();
                    }
                }
                else
                {
                    PortalEnterNaranja.Play();
                }
                teleportEnabler.DesactivarTeleportacion();
                


            }
        }
        bool EsTeleportable()
        {
            return (other.CompareTag("Cubo") || other.CompareTag("CuboToba") || (other.CompareTag("PortalGun") || (other.CompareTag("Player") || (other.CompareTag("BolaEnergia")))));
            

        }
    }


    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(esteleportable);
        if (cubo.velocity.magnitude > maxVelocidadPortal)
        {
            cubo.velocity = Vector3.ClampMagnitude(cubo.velocity, maxVelocidadPortal);
        }
        
        if (portalGunVel.velocity.magnitude > maxVelocidadPortal)
        {
            portalGunVel.velocity = Vector3.ClampMagnitude(portalGunVel.velocity, maxVelocidadPortal);
        }


        
        
       
    }

    public float minSpeedForBoost = 4f;
    public float BoostSpeed = 1.3f;
    float outMagnitude;
    public Transform outDir;
    private Vector3 rotacionoriginal;

    void Teleportar(Collider obj)
    {
        #region CALCULO V3

        #endregion
        var P = portalDestino.GetComponent<Teleportacion>();
        var RB = obj.GetComponent<Rigidbody>();
        rotacionoriginal = obj.transform.rotation.eulerAngles;
        obj.transform.forward = outDir.localEulerAngles.normalized;
        outMagnitude = RB.velocity.magnitude;

        if (RB.velocity.magnitude < minSpeedForBoost)
        {
            RB.velocity *= BoostSpeed;
        }
        obj.transform.position = P.outDir.position;
        obj.transform.rotation = P.outDir.rotation;

        RB.velocity = obj.transform.forward * RB.velocity.magnitude;
        

        if (portalDestino.rotation == Quaternion.Euler(0, 0, 90))
        {
            obj.transform.rotation = Quaternion.Euler(rotacionoriginal.x, rotacionoriginal.y, rotacionoriginal.z+180);
        }

        else
        {
            obj.transform.rotation = Quaternion.Euler(rotacionoriginal.x, rotacionoriginal.y, rotacionoriginal.z);
        }
        //vectorEntrada = obj.GetComponent<Rigidbody>().velocity.normalized;
        //Debug.Log(RB.velocity.magnitude);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position + outDir.forward);
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    //}
}


/*public Transform portalDestino;
    public Vector3 rotacionPortalDestino;
    public Vector3 vectorEntrada;
    public Vector3 vectorSalida;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rotacionPortalDestino = portalDestino.rotation;
        Debug.Log("Rotacion portal: " + rotacionPortalDestino);

        vectorEntrada = player.GetComponent<Rigidbody>().velocity;
        vectorSalida = (Quaternion.Euler(rotacionPortalDestino) * -vectorEntrada); // le agrega la rotacion del portal
        player.transform.position = portalDestino.position;
        player.GetComponent<Rigidbody2D>().velocity = vectorSalida;
    }
*/