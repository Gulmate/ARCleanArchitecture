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