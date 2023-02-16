using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarLayer : MonoBehaviour
{
    public Transform portalAzul;
    public Transform portalNaranja;
    public float distanciaPortal;
    public bool esteleportable;
    private GameObject target;
    private GameObject target2;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(esteleportable);

        if (other.gameObject.CompareTag("PortalGun") || other.gameObject.CompareTag("Cubo") || other.gameObject.CompareTag("BolaEnergia"))
        {
            esteleportable = true;
            target = other.gameObject;
            

        }
        

        //if(other.gameObject != target)
        //{
        //    target2 = other.gameObject;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        esteleportable = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //target.GetComponent<TeleportEnabler>().PuedeTeleportarse

        //Debug.Log(target2);
        if (target != null)
        {
            if (esteleportable == true && Vector3.Distance(target.transform.position, portalAzul.transform.position) < distanciaPortal || Vector3.Distance(target.transform.position, portalNaranja.transform.position) < distanciaPortal)
            {

                //Debug.Log("Pene");
                target.layer = LayerMask.NameToLayer("layerNoPiso");


            }

            else
            {
                target.layer = LayerMask.NameToLayer("Interactable");
                target = null;
            }
        }
        //if (esteleportable == true && Vector3.Distance(target2.transform.position, portalAzul.transform.position) < distanciaPortal || Vector3.Distance(target2.transform.position, portalNaranja.transform.position) < distanciaPortal)
        //{
        //    target2.layer = LayerMask.NameToLayer("layerNoPiso");


        //}

        //else
        //{
        //    target2.layer = LayerMask.NameToLayer("Interactable");
        //    target2 = null;
        //}
    }
}
