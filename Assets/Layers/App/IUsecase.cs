using System;
using UnityEngine;

public interface IUsecase
{
    
}

public class ColorEventArgs: EventArgs
{
    public Color NewColor { get; set; }
    public ColorEventArgs(Color newColor)
    {
        NewColor = newColor;
    }
}

public class SizeEventArgs : EventArgs
{
    public float NewSize { get; set; }
    public SizeEventArgs(float newSize)
    {
        NewSize = newSize;
    }
}

public class RotateEventArgs : EventArgs
{
    public Vector3 rotation { get; set; }
    public RotateEventArgs(Vector3 newRotation)
    {
        rotation = newRotation;
    }
}