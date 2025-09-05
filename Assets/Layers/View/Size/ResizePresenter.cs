using System;
using UnityEngine;
using VContainer;

public class ResizePresenter : MonoBehaviour
{
    private ScaleUsecase _usecase;
    [Inject]
    public CubeTransformator infrastructure;

    public void AddListenerOnSizeChanged(Action<float> listener)
    {
        _usecase.AddListener(listener);
    }

    void Awake()
    {
        _usecase= new ScaleUsecase(infrastructure);
    }

    public void ResizeCube(float newSize)
    {
        _usecase.ResizeCube(newSize);
    }

    public float GetCubeSize()
    {
        return _usecase.GetCubeSize();
    }
}

