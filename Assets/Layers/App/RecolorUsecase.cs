using System;
using UnityEngine;

public class RecolorUsecase: IUsecase
{
    public EventHandler<ColorEventArgs> OnColorChanged;
    private readonly CubeInfrastructure _infrastructure;

    public RecolorUsecase(CubeInfrastructure infrastructure)
    {
        _infrastructure = infrastructure;
    }

    public void RecolorCube(Color newColor)
    {
        _infrastructure.ReColor(newColor);
        OnColorChanged?.Invoke(this, new ColorEventArgs(newColor));
    }

    public Color GetCubeColor()
    {
        return _infrastructure.GetColor();
    }

}
