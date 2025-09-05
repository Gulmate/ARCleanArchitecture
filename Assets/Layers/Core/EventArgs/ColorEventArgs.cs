using System;
using UnityEngine;

public class ColorEventArgs : EventArgs
{
    public Color NewColor { get; set; }
    public ColorEventArgs(Color newColor)
    {
        NewColor = newColor;
    }
}
