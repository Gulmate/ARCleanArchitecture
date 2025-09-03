using System;
using UnityEngine;

public class ScaleUsecase: IUsecase
{
    public EventHandler<SizeEventArgs> OnSizeChanged;
    private readonly CubeInfrastructure _infrastructure;

    public ScaleUsecase(CubeInfrastructure infrastructure)
    {
        _infrastructure = infrastructure;
    }

    public void ResizeCube(float size)
    {
        _infrastructure.Resize(size);
        OnSizeChanged?.Invoke(this, new SizeEventArgs(size));
    }

    public float GetCubeSize()
    {
        return _infrastructure.GetSize();
    }
}
