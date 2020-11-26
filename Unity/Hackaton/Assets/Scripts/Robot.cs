using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Axis { x,y,z};
public class Robot : MonoBehaviour
{
    [SerializeField] private GameObject arm1, arm2, arm3, arm4, handRotator, hand, claw1, claw2;
    [SerializeField] private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
    }

    private IEnumerator RotateTo(GameObject target, Axis axis, float angle)
    {
        float endRotation;
        float currentRotation;
        float lerpPos = 0.0f;
        switch (axis)
        {
            case Axis.x:
                currentRotation = target.transform.localRotation.x;
                endRotation = target.transform.localRotation.x + angle;
                break;
            case Axis.y:
                currentRotation = target.transform.localRotation.y;
                endRotation = target.transform.localRotation.y + angle;
                break;
            case Axis.z:
                currentRotation = target.transform.localRotation.z;
                endRotation = target.transform.localRotation.z + angle;
                break;
            default:
                break;
        }
        while (lerpPos >= 1.0f)
        {

        }
        yield return new WaitForEndOfFrame();
    }
}
