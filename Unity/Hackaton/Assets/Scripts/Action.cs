using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : ScriptableObject
{
    public Axis axis;
    public float angle;

    public Action()
    {
        axis = Axis.y;
        angle = 45.0f;
    }
}
