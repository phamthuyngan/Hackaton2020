using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GrabTrigger : MonoBehaviour
{
    private LanguagueBalls grabbedObj;
    private Robot arm;

    private void Awake()
    {
        arm = GetComponentInParent<Robot>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (arm.isGrabbing && other.TryGetComponent(out grabbedObj))
            grabbedObj.GetGrabbed(transform);
        else if (!arm.isGrabbing && grabbedObj != null)
            grabbedObj.GetReleased();
    }
}
