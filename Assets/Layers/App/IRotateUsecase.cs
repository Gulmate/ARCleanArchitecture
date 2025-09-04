using System;
using UnityEngine;

public interface IRotateUsecase
{
    public void RotateCube(Vector3 rotation);
    public Vector3 GetCubeRotation();
    public void onChange(Action<Vector3> listener);
}

public class RotateEventArgs : EventArgs
{
    public Vector3 rotation { get; set; }
    public RotateEventArgs(Vector3 newRotation)
    {
        rotation = newRotation;
    }
}