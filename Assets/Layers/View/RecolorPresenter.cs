using System;
using UnityEngine;

public class RecolorPresenter : MonoBehaviour, ICubePresenter
{
    private RecolorUsecase _usecase;
    public void AddListenerOnColorChanged(Action<Color> listener)
    {
        _usecase.OnColorChanged += new EventHandler<ColorEventArgs>(delegate (object sender, ColorEventArgs event_arg)
        {
            listener(event_arg.NewColor);
        });
    }

    void Awake()
    {
        CubeInfrastructure infrastructure = new CubeInfrastructure();
        _usecase = new RecolorUsecase(infrastructure);
    }

    public void RecolorCube(Color newColor)
    {
        _usecase.RecolorCube(newColor);
    }

    public Color GetCubeColor()
    {
        return _usecase.GetCubeColor();
    }
}
