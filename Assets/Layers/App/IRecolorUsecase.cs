using System;
using UnityEngine;

public interface IRecolorUsecase
{
    public void RecolorCube(Color newColor);
    public Color GetCubeColor();

    public void onChange(Action<Color> listener);
}

public class ColorEventArgs: EventArgs
{
    public Color NewColor { get; set; }
    public ColorEventArgs(Color newColor)
    {
        NewColor = newColor;
    }
}

