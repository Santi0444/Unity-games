using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPlataforma3 : MonoBehaviour
{
    private Animator Ascensor;
    public bool Apretado = true;
    // Start is called before the first frame update
    void Start()
    {
        Ascensor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SubirPlataforma()
    {
        Ascensor.SetBool("sube", true); 
    }

    public void PonerFalse()
    {
        Ascensor.SetBool("sube", false);
        Ascensor.SetBool("Puedesubir", false);
    }

    public void ponerfls()
    {
        Invoke("PonerFalse", 4);
    }
   
}
