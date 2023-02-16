using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarSlots : MonoBehaviour
{
    public GameObject slotCintura;
    public GameObject slotCintura2;
    public GameObject slotEspalda;
    public GameObject slotEspalda2;
    public Transform posicionCinturonGeneral;
    public float distanciaCinturon;

    private Transform ObjetoAgarrado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ObjetoAgarrado);
    }

    public void ActivarSlot()
    {
        slotCintura.SetActive(true);
        slotCintura2.SetActive(true);
        slotEspalda.SetActive(true);
        slotEspalda2.SetActive(true);
    }
    public void OnTriggerEnter(Collider other)
    {
        ObjetoAgarrado = other.transform;
    }

    public void OnTriggerExit(Collider other)
    {
        ObjetoAgarrado = null;
    }
    //public void DesactivarSlot()
    //{
    //    if (Vector3.Distance(ObjetoAgarrado.transform.position, posicionCinturonGeneral.transform.position) > distanciaCinturon)
    //    {
    //        slotCintura.SetActive(false);
    //        slotCintura2.SetActive(false);
    //        slotEspalda.SetActive(false);
    //        slotEspalda2.SetActive(false);
    //    }
    //}


}
