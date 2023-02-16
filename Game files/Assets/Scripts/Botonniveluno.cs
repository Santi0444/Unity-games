using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botonniveluno : MonoBehaviour
{
    
    public Animator subebaja;
    
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
        subebaja.SetBool("ON", true);
       
    }
    private void OnTriggerExit(Collider other)
    {
        subebaja.SetBool("ON", false);
    }

}
