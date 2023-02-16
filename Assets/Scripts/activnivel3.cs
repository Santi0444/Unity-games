using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activnivel3 : MonoBehaviour
{
    public GameObject niv2;
    public GameObject niv3;
    // Start is called before the first frame update
    void Start()
    {
        niv3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnTriggerEnter(Collider other)
    {
        niv2.SetActive(false);
        niv3.SetActive(true);
    }
}
