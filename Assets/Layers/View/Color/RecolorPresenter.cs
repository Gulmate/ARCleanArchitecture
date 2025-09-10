using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class RecolorPresenter : MonoBehaviour
{
    private RecolorUsecase _usecase;

    [Inject]
    private CubeTransformator infrastructure;
    public void AddListenerOnColorChanged(Action<Color> listener)
    {
        _usecase.onChange(listener);
    }

    [Inject]
    void Awake()
    {
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

    public float ChangeRed(float value)
    {
        var color = _usecase.GetCubeColor();
        color.r = value;
        RecolorCube(color);
        return color.r;
    }

    public float ChangeGreen(float value)
    {
        var color = GetCubeColor();
        color.g = value;
        RecolorCube(color);
        return color.g;
    }

    public float ChangeBlue(float value)
    {
        var color = GetCubeColor();
        color.b = value;
        RecolorCube(color);
        return color.b;
    }

    public float ChangeAlpha(float value)
    {
        var color = GetCubeColor();
        color.a = value;
        RecolorCube(color);
        return color.a;
    }


}
