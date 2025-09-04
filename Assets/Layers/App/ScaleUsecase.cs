using System;

public class ScaleUsecase: IUsecase
{
    public EventHandler<SizeEventArgs> OnSizeChanged;
    private readonly ICubeInfrastructure _infrastructure;

    public ScaleUsecase(ICubeInfrastructure infrastructure)
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
