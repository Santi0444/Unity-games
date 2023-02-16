using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerNiveles : MonoBehaviour
{
    public GameObject Nivel1;
    public GameObject Nivel2;
    public GameObject Nivel3;
    // Start is called before the first frame update
    void Start()
    {
        if(ButtonInteraction.NivelActual == 1)
        {
            Nivel1.SetActive(true);
            Nivel2.SetActive(false);
            Nivel3.SetActive(false);
        }

        if (ButtonInteraction.NivelActual == 2)
        {
            Nivel1.SetActive(false);
            Nivel2.SetActive(true);
            Nivel3.SetActive(false);
        }

        if (ButtonInteraction.NivelActual == 3)
        {
            Nivel1.SetActive(false);
            Nivel2.SetActive(false);
            Nivel3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
