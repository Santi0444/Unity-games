using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform OtherPortal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mueve la posicion
        Vector3 offset = playerCamera.position - OtherPortal.position;
        transform.position = portal.position - offset;

        //Mueve la rotacion
        float angle = Quaternion.Angle(portal.rotation, OtherPortal.rotation);
        Quaternion angleToQuaternion = Quaternion.AngleAxis(angle, Vector3.up);
        Vector3 dir = angleToQuaternion * -playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(
            new Vector3(dir.x, -dir.y, dir.z), Vector3.up);
    }
}

//Vector3 playerOffsetFromPortal = playerCamera.position - OtherPortal.position;
//transform.position = portal.position + new Vector3(-playerOffsetFromPortal.x, playerOffsetFromPortal.y, -playerOffsetFromPortal.z);

//float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, OtherPortal.rotation);

//Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
//Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
//transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);