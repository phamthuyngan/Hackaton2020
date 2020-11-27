using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class GameButton : MonoBehaviour
{
    [SerializeField] private Axis axis;
    [SerializeField] private float angle;
    [SerializeField] private int objIndex;
    private UIManager uiManager;
    private Button button;
    private Image image;
    public bool noAction = false;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    public void AddToList()
    {
        uiManager.AddAction(objIndex, CreateAction(), image);
    }

    public void RemoveFromList()
    {
        uiManager.RemoveAction(objIndex);
    }
    private Action CreateAction()
    {
        if (noAction)
            return null;
        Action action = (Action)ScriptableObject.CreateInstance(typeof(Action));
        action.axis = axis;
        action.angle = angle;
        return action;
    }
}
