using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnabler : MonoBehaviour
{
    public bool puedeTeleportarse;
    public float TiempoHastaTeletransportarse;
   
    public bool PuedeTeleportarse { get => puedeTeleportarse; set => puedeTeleportarse = value; }

    public void DesactivarTeleportacion()
    {
        PuedeTeleportarse = false;
        Invoke(nameof(ReActivarTeleportacion), TiempoHastaTeletransportarse);
    }

    private void ReActivarTeleportacion()
    {
        PuedeTeleportarse = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
