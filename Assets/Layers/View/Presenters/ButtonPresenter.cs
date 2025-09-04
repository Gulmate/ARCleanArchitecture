using System;
using UnityEngine;
using VContainer;

public class ButtonPresenter : MonoBehaviour
{
    private IFileUsecase _usecase;

    [Inject]
    private CubeInfrastructure infrastructure;

    public void AddListenerOnPressed(Action<float, Color, Vector3> onClicked)
    {
        _usecase.onPressed(onClicked);
    }

    [Inject]
    void Awake()
    {
        _usecase = new FileUsecase(infrastructure);
    }

    public void SaveCube()
    {
        _usecase.SaveCube();
    }

    public void LoadCube()
    {
        _usecase.LoadCube();
    }

    
}
