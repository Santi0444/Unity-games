using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamaraSlot : MonoBehaviour
{
    [Range(0.5f, 0.75f)]
    public float altura = 0.5f;

    private Transform Cabeza = null;
    
    // Start is called before the first frame update
    void Start()
    {
        Cabeza = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, camara.transform.position.y - 0.7f, transform.position.z), 10);
        //transform.localPosition = Vector3.MoveTowards(transform.position, camara.forward, 10);
        //transform.localPosition = Vector3.Slerp(camara.forward, camara.right, 5);
        posicionAbajo();
        RotarCabeza();
    }

    private void posicionAbajo()
    {
        Vector3 AlturaAjustada = Cabeza.position;
        AlturaAjustada.x = Cabeza.position.x - 0.25f;
        AlturaAjustada.y = Mathf.Lerp(0.0f, AlturaAjustada.y, altura);

        transform.position = AlturaAjustada;
    }

    private void RotarCabeza()
    {
        Vector3 rotacionAjustada = Cabeza.eulerAngles;
        rotacionAjustada.x = 0;
        rotacionAjustada.z = 0;

        transform.localEulerAngles = rotacionAjustada;
    }
}
