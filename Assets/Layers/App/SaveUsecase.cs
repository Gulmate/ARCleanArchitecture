using System;
using UnityEngine;
using VContainer;

public class FileUsecase : IFileUsecase
{
    public event EventHandler<ButtonEventArgs> OnButtonPressed;
    private readonly ICubeInfrastructure _infrastructure;

    [Inject]
    public FileUsecase(ICubeInfrastructure infrastructure)
    {
        _infrastructure = infrastructure;
    }

    public void SaveCube()
    {
        _infrastructure.Save();
    }

    public void LoadCube()
    {
        _infrastructure.Load();
        OnButtonPressed?.Invoke(this, new ButtonEventArgs(_infrastructure.GetSize(), _infrastructure.GetColor(), _infrastructure.GetRotation()));
    }

    public void onPressed(Action<float, Color, Vector3> onClicked)
    {
        OnButtonPressed += new EventHandler<ButtonEventArgs>(delegate (object sender, ButtonEventArgs event_arg)
        {
            onClicked(event_arg.size, event_arg.color, event_arg.rotation);
        });
    }
}
