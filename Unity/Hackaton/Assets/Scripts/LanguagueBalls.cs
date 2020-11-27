using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Language {CSharp,JavaScript,HTML,CSS};
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class LanguagueBalls : MonoBehaviour
{
    public Language language;
    private Transform childBillboard;
    private Transform cam;
    private Vector3 originalPosition;
    private Rigidbody rb;
    void Awake()
    {
        childBillboard = transform.GetChild(0);
        cam = FindObjectOfType<Camera>().transform;
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        childBillboard.LookAt(cam);
    }

    public void Reset()
    {
        transform.SetPositionAndRotation(originalPosition, Quaternion.identity);
        GetReleased();
    }

    public void GetGrabbed(Transform parent)
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        transform.parent = parent;
        transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
    }
    public void GetReleased()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        transform.parent = null;
        transform.SetPositionAndRotation(originalPosition, Quaternion.identity);
    }
}
