using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabTwoAttach : XRGrabInteractable
{
    public Transform leftAttachTranfrom;
    public Transform RightAttachTranfrom;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftAttachTranfrom;
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            attachTransform = RightAttachTranfrom;
        }

        base.OnSelectEntered(args);
    }
}
