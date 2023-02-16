using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciabolaenergia : MonoBehaviour
{
    public Transform bola;
    public bool tocounavez =true;
    public Animator tirador;
    public Transform instanciador;

    public GameObject colliderpata;

    public AudioSource spawnerAbrir;
    public AudioSource spawnerCerrar;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Esperar3S());
        Esperar3S();

        colliderpata.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tirarbola()
    {
        if (tocounavez == true)
        {
            spawnerAbrir.Play();
            tirador.SetBool("Tirobola", true);
            
            bola.transform.position = instanciador.transform.position;
            bola.transform.rotation = instanciador.transform.rotation;
            tocounavez = false;
            //tirador.SetBool("yasalio", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tirador.SetBool("Tirobola", false);
        tirador.SetBool("yasalio", true);
        colliderpata.SetActive(true);
    }

    public IEnumerator Esperar3S()
    {
        yield return new WaitForSeconds(3);
        Tirarbola();
    }
}
