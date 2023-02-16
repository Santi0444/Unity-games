using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarJugador : MonoBehaviour
{
    public Transform playerCamera;
    private Transform Piso;
    // Start is called before the first frame update
    void Start()
    {
        Piso = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Piso.transform.rotation = Quaternion.LookRotation(playerCamera.position);
    }
}
