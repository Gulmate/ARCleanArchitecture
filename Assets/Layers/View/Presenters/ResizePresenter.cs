using System;
using UnityEngine;
using VContainer;

public class ResizePresenter : MonoBehaviour, ICubeSizePresenter
{
    private IScaleUsecase _usecase;
    [Inject]
    public CubeInfrastructure infrastructure;

    public void AddListenerOnSizeChanged(System.Action<float> listener)
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

