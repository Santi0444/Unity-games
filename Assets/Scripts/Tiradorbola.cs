using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiradorbola : MonoBehaviour
{
    public Animator tirador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        tirador.SetBool("Tirobola", true);
        tirador.SetBool("yasalio", false);
    }
    private void OnTriggerExit(Collider other)
    {
        tirador.SetBool("Tirobola", false);
        tirador.SetBool("yasalio", true);
    }

}
