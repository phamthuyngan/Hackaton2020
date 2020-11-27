using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RectTransform))]
public class ArmNode : MonoBehaviour
{
    private Camera cam;
    private Transform target;
    [SerializeField] private string targetName;
    void Awake()
    {
        cam = FindObjectOfType<Camera>();
        target = GameObject.Find(targetName).transform;
    }

    void Update()
    {
        transform.position = cam.WorldToScreenPoint(target.position);
    }
}
