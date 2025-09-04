using System;
using UnityEngine;
using VContainer;
public class RotateUsecase : IRotateUsecase
{
    public EventHandler<RotateEventArgs> OnRotationChanged;
    private readonly ICubeInfrastructure _infrastructure;

    [Inject]
    public RotateUsecase(ICubeInfrastructure infrastructure)
    {
        _infrastructure = infrastructure;
    }

    public void RotateCube(Vector3 rotation)
    {
        _infrastructure.Rotate(rotation);
        OnRotationChanged?.Invoke(this, new RotateEventArgs(rotation));
    }

    public Vector3 GetCubeRotation()
    {
        return _infrastructure.GetRotation();
    }

    public void onChange(Action<Vector3> listener)
    {
        OnRotationChanged += new System.EventHandler<RotateEventArgs>(delegate (object sender, RotateEventArgs event_arg)
        {
            listener(event_arg.rotation);
        });
    }
}
