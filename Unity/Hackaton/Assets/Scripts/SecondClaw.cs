using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondClaw : MonoBehaviour
{
    [SerializeField] private GameObject firstClaw;
    void Update()
    {
        this.transform.localEulerAngles = firstClaw.transform.localEulerAngles + new Vector3(-180.0f, 0.0f,0.0f);
    }
}
