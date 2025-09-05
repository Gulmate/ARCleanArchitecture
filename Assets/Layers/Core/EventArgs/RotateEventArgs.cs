using System;
using UnityEngine;

public class RotateEventArgs : EventArgs
{
    public Vector3 rotation { get; set; }
    public RotateEventArgs(Vector3 newRotation)
    {
        rotation = newRotation;
    }
}
