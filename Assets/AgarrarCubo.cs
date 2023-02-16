using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarCubo : MonoBehaviour
{
    public Transform cubo;
    public bool agarrar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agarrar)
        {
           
        }

        else
        {
            cubo.rotation = Quaternion.identity;
        }
            
    }
}
