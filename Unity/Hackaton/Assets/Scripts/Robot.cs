using System.Collections;
using UnityEngine;

public enum Axis { x, y, z };
public class Robot : MonoBehaviour
{
    [SerializeField] private GameObject[] parts; 
    [Range(0.0f, 5.0f)][SerializeField] private float rotationSpeed;
    public bool isGrabbing { get; private set; }

    private void Update()
    {
        if (parts[parts.Length - 1].transform.rotation.z <= 0.1f)
            isGrabbing = true;
        else
            isGrabbing = false;
    }
    public void ResetRotation()
    {
        for (int i = 0; i < parts.Length - 2; i++)
            parts[i].transform.localEulerAngles = new Vector3();
        parts[parts.Length - 1].transform.localEulerAngles = new Vector3(0.0f,0.0f,-12.5f);
    }

    public void MovePart(int objIndex, Action action)
    {
        StartCoroutine(RotateTo(parts[objIndex], action.axis, action.angle));
    }
    private IEnumerator RotateTo(GameObject part, Axis axis, float angle) // makes the object rotate until a desired angle 
    {
        float endRotation = 0.0f;
        float currentRotation = 0.0f;
        float lerpPos = 0.0f;
        switch (axis)
        {
            case Axis.x:
                currentRotation = part.transform.localEulerAngles.x;
                endRotation = part.transform.localEulerAngles.x + angle;
                break;
            case Axis.y:
                currentRotation = part.transform.localEulerAngles.y;
                endRotation = part.transform.localEulerAngles.y + angle;
                break;
            case Axis.z:
                currentRotation = part.transform.localEulerAngles.z;
                endRotation = part.transform.localEulerAngles.z + angle;
                break;
            default:
                break;
        }
        while (lerpPos < 1.0f)
        {
            lerpPos += rotationSpeed * Time.deltaTime;

            switch (axis)
            {
                case Axis.x:
                    part.transform.localEulerAngles =  new Vector3(Mathf.LerpAngle(currentRotation, endRotation, lerpPos), part.transform.localEulerAngles.y, part.transform.localEulerAngles.z);
                    break;
                case Axis.y:
                    part.transform.localEulerAngles = new Vector3(part.transform.localEulerAngles.x, Mathf.LerpAngle(currentRotation, endRotation, lerpPos), part.transform.localEulerAngles.z);
                    break;
                case Axis.z:
                    part.transform.localEulerAngles = new Vector3(part.transform.localEulerAngles.x, part.transform.localEulerAngles.y, Mathf.LerpAngle(currentRotation, endRotation, lerpPos));
                    break;
                default:
                    break;
            }
            yield return new WaitForEndOfFrame();
        }
      
    }

}
