using System;
using UnityEngine;
using VContainer;

public class ButtonPresenter : MonoBehaviour
{
    private FileUsecase _usecase;

    [Inject]
    private CubeTransformator transformator;

    [Inject]
    private readonly CubeFileHandler fileHandler;

    public void AddListenerOnPressed(Action<float, Color, Vector3> onClicked)
    {
        _usecase.onPressed(onClicked);
    }

    [Inject]
    void Awake()
    {
        _usecase = new FileUsecase(fileHandler, transformator);
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
