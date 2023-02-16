using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciacubo2 : MonoBehaviour
{
    public GameObject cubo;
    public Transform InstanciadorPosicion;
    public float spawnTime;
    public bool Spawnear;
    public Destruircubos destruidor;
    // Use this for initialization
    void Start()
    {
        
        InvokeRepeating("SpawnBall", spawnTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (destruidor.DestruyoCubo == true)
        {
            Invoke("SpawnBall", 2);
            destruidor.DestruyoCubo = false;
        }
        //Debug.Log(Spawnear);
    }
    void SpawnBall()
    {
        if (destruidor.DestruyoCubo == true)
        {
            cubo.transform.position = InstanciadorPosicion.transform.position;
        }
    }

}
