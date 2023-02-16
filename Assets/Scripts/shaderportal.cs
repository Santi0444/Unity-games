using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;

public class shaderportal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderTextureDescriptor d = XRSettings.eyeTextureDesc;
        d.width = d.width / -2; // THIS DOES NOT MAKE SENSE
        RenderTexture t = new RenderTexture(d);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
