using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter2 : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            Vector3 playerFromPortal = transform.InverseTransformPoint(player.transform.position);
            if (playerFromPortal.z <= 0.02)
            {
                player.transform.position = receiver.position + new Vector3(-playerFromPortal.x, +playerFromPortal.y, -playerFromPortal.z);
                Quaternion ttt = Quaternion.Inverse(transform.rotation) * player.transform.rotation;
                player.transform.eulerAngles = Vector3.up * (receiver.eulerAngles.y - (transform.eulerAngles.y - player.transform.eulerAngles.y) + 180);
                Vector3 CamLEA = Camera.main.transform.localEulerAngles;
                Camera.main.transform.localEulerAngles = Vector3.right * (receiver.eulerAngles.x + Camera.main.transform.localEulerAngles.x);
            }
        }
    }
}
