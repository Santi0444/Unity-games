using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BotonVR : MonoBehaviour
{
    public Transform boton;
    public UnityEvent OnPress;
    public UnityEvent OnRelease;
    GameObject Presser;

    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            boton.transform.localPosition = new Vector3(0, 0.05f, 0);
            Presser = other.gameObject;
            OnPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Presser)
        {
            boton.transform.localPosition = new Vector3(0, 0.12f, 0);
            OnRelease.Invoke();
            isPressed = false;
        }
    }

   

}
