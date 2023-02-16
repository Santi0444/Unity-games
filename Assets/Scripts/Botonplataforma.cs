using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botonplataforma : MonoBehaviour
{
    public Animator subebaja;
    private Animator Ascensor;
    public Transform Subebaja;
    public GameObject SubebajaLayer;
    public bool OFF = false;
    public bool SeApreto;
    private Instanciacubo instanciador;
    // Start is called before the first frame update
    void Start()
    {
        instanciador = GetComponent<Instanciacubo>();
        Ascensor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("el boton esta " + SeApreto);
        if (Subebaja.transform.position.y < -2.3f)
        {
            SubebajaLayer.layer = LayerMask.NameToLayer("Default");
            SubebajaLayer.gameObject.tag = "Default";

        }
        
        else
        {
            SubebajaLayer.layer = LayerMask.NameToLayer("Posible");
            SubebajaLayer.gameObject.tag = "Posible";
        }

        //Debug.Log(instanciador.Spawnear);
        if (SeApreto == true)
        {
            
            Ascensor.SetBool("ON", true);
            SeApreto = false;
            OFF = true;
            
        }

        else if (OFF == true)
        {
            
            //subebaja.SetBool("OFF", false);
            //Ascensor.SetBool("sube", false);
            //subebaja.SetBool("ON", false);
            OFF = false;
           
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
       

        
    }

    public void SubirPlataforma()
    {
        
        SeApreto = true;
        

    }
    
    public void BajarPlataforma()
    {
        
        SeApreto = false;
        

    }
    

    
}
