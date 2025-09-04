using System;
using UnityEngine;
using VContainer;

public class RecolorUsecase: IRecolorUsecase
{
    public EventHandler<ColorEventArgs> OnColorChanged;
    private readonly ICubeInfrastructure _infrastructure;

    [Inject]
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

    public void onChange(Action<Color> listener)
    {
        OnColorChanged += new EventHandler<ColorEventArgs>(delegate (object sender, ColorEventArgs event_arg)
        {
            listener(event_arg.NewColor);
        });
    }

}
