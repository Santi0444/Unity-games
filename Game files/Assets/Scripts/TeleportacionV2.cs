using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportacionV2 : MonoBehaviour
{
    public GameObject Prefab;
    private Transform prefab;
    private Transform Cubo;
    public Transform portal;
    // Start is called before the first frame update
    void Start()
    {
        Cubo = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanciaAlPortal = Cubo.transform.position - portal.transform.position;

        if (distanciaAlPortal == new Vector3(0.0f, 0.0f, -0.1f))
        {
            Debug.Log("putaaaaaaaaaaaaaa");
        }
        //Debug.Log(distanciaAlPortal);
    }
}