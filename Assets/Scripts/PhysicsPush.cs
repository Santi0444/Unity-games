using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsPush : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    public ConfigurableJoint joint;

    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }


    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Apretado");
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("No apretado");
    }

    // Update is called once per frame
    void Update()
    {

       if (!isPressed && GetValue() + threshold >= 1)
       {
            Pressed();
       }

       if (isPressed && GetValue() - threshold <= 0)
       {
            Released();
       }
    }

    public void Mensaje()
    {
        //Debug.Log("La concha de tu hermana");
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadZone)
        
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }
}
