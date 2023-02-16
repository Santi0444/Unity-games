using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRoffsetGrab : XRGrabInteractable
{
    private Vector3 interactorPos = Vector3.zero;
    private Quaternion interactorRot = Quaternion.identity;

    [System.Obsolete]
    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        base.OnSelectEntering(interactor);
        StoreInteractor(interactor);
        MatchAttachmentPoints(interactor);
    }

    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPos = interactor.attachTransform.localPosition;
        interactorRot = interactor.attachTransform.localRotation;
    }

    private void MatchAttachmentPoints(XRBaseInteractor interactor)
    {
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position: transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation: transform.rotation;
    }

    [System.Obsolete]
    protected override void OnSelectExiting(XRBaseInteractor interactor)
    {
        base.OnSelectExiting(interactor);
        ResetAttachmentPoints(interactor);
        ClearInteractor(interactor);
    }

    private void ResetAttachmentPoints(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPos;
        interactor.attachTransform.localRotation = interactorRot;
    }

    private void ClearInteractor(XRBaseInteractor interactor)
    {
        interactorPos = Vector3.zero;
        interactorRot = Quaternion.identity;
    }
}
