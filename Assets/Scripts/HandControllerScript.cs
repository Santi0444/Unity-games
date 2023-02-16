using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandControllerScript : MonoBehaviour
{
    [SerializeField] InputActionReference gripInput;
    [SerializeField] InputActionReference TriggerInput;

    Animator handAnimator;

    private void Awake()
    {
        handAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gripInput.action.performed += GripPressed;
        TriggerInput.action.performed += TriggerPressed;
    }

    private void TriggerPressed(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }
    private void GripPressed(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }

    private void OnDisable()
    {
        gripInput.action.performed -= GripPressed;
        TriggerInput.action.performed -= TriggerPressed;
    }

}
