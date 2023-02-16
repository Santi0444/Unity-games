using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevadorhijo : MonoBehaviour
{
    public Animator ascensor;
    public Transform Ascensorgo;
    public GameObject jugador;

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
        if (other.gameObject.CompareTag("Player")) {
            ascensor.SetBool("sube", true);
            jugador.transform.SetParent(Ascensorgo);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ascensor.SetBool("sube", false);
            jugador.transform.SetParent(null);
        }
    }
}
