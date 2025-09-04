using System;
using VContainer;

public class ScaleUsecase: IScaleUsecase
{
    public EventHandler<SizeEventArgs> OnSizeChanged;
    private readonly ICubeInfrastructure _infrastructure;

    [Inject]
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

    public void AddListener(System.Action<float> listener)
    {
        OnSizeChanged += new System.EventHandler<SizeEventArgs>(delegate (object sender, SizeEventArgs event_arg)
        {
            listener(event_arg.NewSize);
        });
    }
}
