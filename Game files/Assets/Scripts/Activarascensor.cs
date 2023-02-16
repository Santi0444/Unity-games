using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activarascensor : MonoBehaviour
{
    public Animator ascensor;
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
        if (other.gameObject.name == "CentroJugador")
        {
            ascensor.SetBool("abrir", true);
        }
    }
}
