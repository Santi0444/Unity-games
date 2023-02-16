using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacionsostenedor : MonoBehaviour
{
    public Animator sostenedor;
    public GameObject Cubo;
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
        
        sostenedor.SetBool("nohaycubo", false);
        sostenedor.SetBool("haycubo", true);
        //Cubo.layer = LayerMask.NameToLayer("LayerNoPiso");
    }
    private void OnTriggerExit(Collider other)
    {
        
        sostenedor.SetBool("nohaycubo", true);
        Cubo.layer = LayerMask.NameToLayer("Interactable");
    }
}
