using System;
using UnityEngine;
using VContainer;

public class ButtonPresenter : MonoBehaviour
{
    private IFileUsecase _usecase;

    [Inject]
    private CubeInfrastructure infrastructure;
    /*public void AddListenerOnPressed(Action<Color> listener)
    {
        _usecase.onPressed(listener);
    }*/

    [Inject]
    void Awake()
    {
        //CubeInfrastructure infrastructure = new CubeInfrastructure();
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
