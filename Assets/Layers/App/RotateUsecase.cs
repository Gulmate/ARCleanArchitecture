using System;
using UnityEngine;

public class RotateUsecase : IUsecase
{
    public EventHandler<RotateEventArgs> OnRotationChanged;
    private readonly CubeInfrastructure _infrastructure;

    public RotateUsecase(CubeInfrastructure infrastructure)
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
