using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarpiso : MonoBehaviour
{
    public GameObject niv2;
    public GameObject niv1;
    public bool primerosNiveles;
    public DisparadorPortales DP;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        DP.SeDisparoPortal = false;
        DP.SeDisparoPortalNaranja = false;
        niv2.SetActive(true);
        niv1.SetActive(false);
    }
}
