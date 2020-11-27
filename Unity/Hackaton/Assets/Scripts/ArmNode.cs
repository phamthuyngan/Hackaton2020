using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RectTransform))]
public class ArmNode : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Transform target;
    void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        transform.position = cam.WorldToScreenPoint(target.position);
    }
}
