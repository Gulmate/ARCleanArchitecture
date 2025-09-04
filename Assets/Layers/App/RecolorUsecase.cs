using System;
using UnityEngine;

public class RecolorUsecase: IUsecase
{
    public EventHandler<ColorEventArgs> OnColorChanged;
    private readonly ICubeInfrastructure _infrastructure;

    public RecolorUsecase(ICubeInfrastructure infrastructure)
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
