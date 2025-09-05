using System;
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
}
