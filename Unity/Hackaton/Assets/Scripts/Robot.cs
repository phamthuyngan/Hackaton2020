using System.Collections;
using UnityEngine;

public enum Axis { x, y, z };
public class Robot : MonoBehaviour
{
    [SerializeField] private GameObject[] parts; 
    [Range(0.0f, 1.0f)][SerializeField] private float rotationSpeed;


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
                currentRotation = part.transform.localRotation.x;
                endRotation = part.transform.localRotation.x + angle;
                break;
            case Axis.y:
                currentRotation = part.transform.localRotation.y;
                endRotation = part.transform.localRotation.y + angle;
                break;
            case Axis.z:
                currentRotation = part.transform.localRotation.z;
                endRotation = part.transform.localRotation.z + angle;
                break;
            default:
                break;
        }
        while (lerpPos < 1.0f)
        {
            lerpPos += rotationSpeed * Time.deltaTime;
            //target.transform.rotation

            switch (axis)
            {
                case Axis.x:
                    part.transform.localRotation = Quaternion.Euler( new Vector3(Mathf.Lerp(currentRotation, endRotation, lerpPos), part.transform.localRotation.y, part.transform.localRotation.z));
                    break;
                case Axis.y:
                    part.transform.localRotation = Quaternion.Euler(new Vector3(part.transform.localRotation.x, Mathf.Lerp(currentRotation, endRotation, lerpPos), part.transform.localRotation.z));
                    break;
                case Axis.z:
                    break;
                    part.transform.localRotation = Quaternion.Euler(new Vector3(part.transform.localRotation.x, part.transform.localRotation.y, Mathf.Lerp(currentRotation, endRotation, lerpPos)));
                default:
                    break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
