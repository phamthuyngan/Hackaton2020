using System.Collections;
using UnityEngine;

public class SocketManager : MonoBehaviour
{
    [SerializeField] private int NbrOfSockets;
    private int NbrCompleted;
    private UIManager uiManager;
    public float movSpeed;
    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        NbrCompleted = 0;
    }
    public void SocketCompleted()
    {
        NbrCompleted++;
        if (NbrCompleted == NbrOfSockets)
        {
            uiManager.Win();
            return ;
        }
        StartCoroutine(MoveAfterCompleted());
    }

    private IEnumerator MoveAfterCompleted()
    {
        float currentPosition = transform.position.x;
        float endPosition = currentPosition + 0.5f;
        float lerpPos = 0.0f;
        while (lerpPos < 1.0f)
        {
            lerpPos += movSpeed * Time.deltaTime;
            transform.position = new Vector3(Mathf.Lerp(currentPosition, endPosition, lerpPos), transform.position.y, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
    }
}
