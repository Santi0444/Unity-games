using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sostenedorscript : MonoBehaviour
{
    public GameObject cubo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSeconds(2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Instantiate(cubo, transform.position, Quaternion.identity);
    }
}
