using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivarUIMuñeca : MonoBehaviour
{
    public InputActionReference ToggleReference;
    private Canvas WristCanvas;
    private InputAction menu;
    // Start is called before the first frame update
    void Start()
    {
        WristCanvas = GetComponent<Canvas>();
        ToggleReference.action.started += ToggleMenu;
        WristCanvas.enabled = false;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {

        WristCanvas.enabled = !WristCanvas.enabled;
        Debug.Log("oppopopo");
    }

    public void ToggleClickMenu()
    {
        WristCanvas.enabled = !WristCanvas.enabled;
    }

    
}
