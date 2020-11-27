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
        if (other.TryGetComponent<LanguagueBalls>(out grabbedObj))
        {
            grabbedObj.GetGrabbed(transform);
           
            //grabbedObj.GetComponent<LanguagueBalls>().GetGrabbed();
        }
        else if (!arm.isGrabbing && grabbedObj != null)
        {
            grabbedObj.GetReleased();
        }
    }
}
