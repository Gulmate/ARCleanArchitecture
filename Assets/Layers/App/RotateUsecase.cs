using System;
using UnityEngine;

public class RotateUsecase : IUsecase
{
    public EventHandler<RotateEventArgs> OnRotationChanged;
    private readonly ICubeInfrastructure _infrastructure;

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
}
