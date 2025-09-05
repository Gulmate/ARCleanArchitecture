using System;
using UnityEngine;

public class ButtonEventArgs : EventArgs
{
    public Color color { get; set; }
    public float size { get; set; }

    public Vector3 rotation { get; set; }
    public ButtonEventArgs(float newSize, Color newColor, Vector3 newRotation)
    {
        color = newColor;
        rotation = newRotation;
        size = newSize;
    }
}

