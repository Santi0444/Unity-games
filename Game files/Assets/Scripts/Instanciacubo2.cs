using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciacubo : MonoBehaviour
{
    public GameObject cubo;
    public Transform InstanciadorPosicion;
    public float spawnTime;
    public bool Spawnear;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnBall", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Spawnear);
    }
    void SpawnBall()
    {
        if (Spawnear == false)
        {
            cubo.transform.position = InstanciadorPosicion.transform.position;
        }
    }
}
