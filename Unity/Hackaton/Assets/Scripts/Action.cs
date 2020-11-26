using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : ScriptableObject
{
    //public int objIndex;
    public Axis axis;
    public float angle;

    public Action()
    {
        //objIndex = 0;
        axis = Axis.y;
        angle = 45.0f;
    }
}
