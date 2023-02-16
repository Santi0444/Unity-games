using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPortales : MonoBehaviour
{
    private Grid grid;
    public DisparadorPortales disparador;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void Update()
    {
        if (disparador.SeDisparoPortal == true)
        {

        }
    }
}
