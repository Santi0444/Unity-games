using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManoEnPortal : MonoBehaviour
{
    public Transform Portal;
    public Transform OtroPortal;
    private Transform Mano;
    private bool Toco = false;
    public GameObject PrefabMano;
    // Start is called before the first frame update
    void Start()
    {
        Mano = gameObject.GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PortalNaranja"))
        {
            Toco = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Toco == true)
        {
            ManoSeguir();
        }
        //Vector3 OffsetMano = Mano.position - Portal.position;
        //Debug.Log(OffsetMano);
    }

    void ManoSeguir()
    {
        Vector3 OffsetMano = Mano.position - Portal.position;
        //Vector3 PosicionPrefab = OtroPortal.position + new Vector3(-OffsetMano.x, OffsetMano.y, -OffsetMano.z);
        Instantiate(PrefabMano, Portal.position, Quaternion.identity);
    }
}
