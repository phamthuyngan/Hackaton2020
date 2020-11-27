using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    [SerializeField] private Language language;
    private LanguagueBalls ball;
    private SocketManager socketManager;
    void Awake()
    {
        socketManager = GetComponentInParent<SocketManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ball))
        {
            if (language == ball.language)
            {
                ball.GetInSocket(transform);
                socketManager.SocketCompleted();
            }
            else
            {
                ball.GetComponent<Rigidbody>().AddForce(new Vector3(0.5f, 5.0f, 0.5f), ForceMode.Impulse);
            }
        }
    }
}
