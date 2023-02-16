using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlataforma : MonoBehaviour
{
    private Transform plataforma;
    public float velocidad;
    public GameObject cubo;
    public ActivadorNivel3 boton;
    public bool esParent;
    // Start is called before the first frame update
    void Start()
    {
        plataforma = gameObject.GetComponent<Transform>();
        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Boton.MoverPlataforma);
        if (boton.fueActivado)
        {
            esParent = true;
            plataforma.transform.Translate(0, velocidad * Time.deltaTime, 0);
        }
        else
        {
            esParent = false;
            plataforma.transform.Translate(0, 0 * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("RielDerecho"))
        {
            velocidad = 0;
            InvokeRepeating("EsperarPlataformaPositivo", 1.5f, 0);
        }
        if (other.gameObject.CompareTag("RielIzquierdo"))
        {
            velocidad = 0;
            InvokeRepeating("EsperarPlataforma", 1.5f, 0);
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cubo"))
        {
            cubo.transform.SetParent(plataforma);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Cubo"))
        {
            cubo.transform.SetParent(null);
        }
    }

    void EsperarPlataforma()
    {
        velocidad = 2f;
    }
    void EsperarPlataformaPositivo()
    {
        velocidad = -2f;
    }
}
