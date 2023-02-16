using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarDistancia : MonoBehaviour
{
    public Transform portalNaranjaPosicion;
    public Transform portalAzulPosicion;
    public Transform JugadorPosicion;
    public Vector3 DistanciaAlPortal;
    public Vector3 DistanciaAlPortalAzul;
    public bool teleportar = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        DistanciaAlPortal = JugadorPosicion.position - portalNaranjaPosicion.position;
        DistanciaAlPortalAzul = JugadorPosicion.position - portalAzulPosicion.position;

       
        

      


        Debug.Log("La distancia al portal naranja es de " + DistanciaAlPortal);
        Debug.Log("La distancia al portal Azul es de " + DistanciaAlPortalAzul);
    }
}
