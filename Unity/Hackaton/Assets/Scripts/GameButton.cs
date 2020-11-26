using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class GameButton : MonoBehaviour
{
    [SerializeField] private Axis axis;
    [SerializeField] private float angle;
    [SerializeField] private int objIndex;
    private UIManager uiManager;
    
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void AddToList()
    {
        uiManager.AddAction(objIndex, CreateAction());
    }
    private Action CreateAction()
    {
        Action action = (Action)ScriptableObject.CreateInstance(typeof(Action));
        action.axis = axis;
        action.angle = angle;
        return action;
    }
}
