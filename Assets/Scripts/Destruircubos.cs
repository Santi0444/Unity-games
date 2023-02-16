using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruircubos : MonoBehaviour
{
    public Transform Cubo;
    public Rigidbody Cubo2;
    public Transform PosicionOriginal;
    public Transform PosicionOriginalNivel2;
    public Transform PosicionOriginalNivel3;
    public bool DestruyoCubo;
    public bool NoRepetir;
    public bool esPortalGun;
    public float TiempoSpawn;
    // Start is called before the first frame update
    void Start()
    {
       SpawnCubo();
    }

    // Update is called once per frame
    void Update()
    {
        if (DestruyoCubo)
        {
            if (NoRepetir)
            {
                Invoke("SpawnCubo", TiempoSpawn);
                DestruyoCubo = false;
            }
            else
            {
                Invoke("SpawnCubo", TiempoSpawn);
                DestruyoCubo = false;
            }
            DestruyoCubo = false;
        }

        
    }

    public void SpawnCubo()
    {
        //Debug.Log("La concha de tu madre");
        //DestruyoCubo = false;
        Cubo2.isKinematic = false;
        if (esPortalGun)
        {
            if (PosicionOriginal.gameObject.activeInHierarchy == false)
            {

                Cubo.position = PosicionOriginalNivel2.position;
                Cubo.rotation = PosicionOriginalNivel2.rotation;
                Cubo2.isKinematic = true;
            }
            else
            {
                Cubo.position = PosicionOriginal.position;
                Cubo.rotation = PosicionOriginal.rotation;
                Cubo2.isKinematic = true;
            }

            if(!PosicionOriginal.gameObject.activeInHierarchy && !PosicionOriginalNivel2.gameObject.activeInHierarchy)
            {
                Cubo.position = PosicionOriginalNivel3.position;
                Cubo.rotation = PosicionOriginalNivel3.rotation;
                Cubo2.isKinematic = true;
            }
        }

        else
        {
            Cubo.position = PosicionOriginal.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rompecubos" || other.gameObject.tag == "Rompecubos2")
        {

            Cubo2.isKinematic = true;
            Cubo.rotation = Quaternion.identity;
            Cubo.transform.position = PosicionOriginal.position;
            DestruyoCubo = true;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "plataforma")
        {
            DestruyoCubo = true;
        }

        else
        {
            DestruyoCubo = false;
            CancelInvoke("SpawnCubo");
        }
    }

}
