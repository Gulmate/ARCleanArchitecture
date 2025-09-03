using UnityEngine;

public class ResizePresenter : MonoBehaviour, ICubeSizePresenter
{
    private ScaleUsecase _usecase;

    public void AddListenerOnSizeChanged(System.Action<float> listener)
    {
        _usecase.OnSizeChanged += new System.EventHandler<SizeEventArgs>(delegate (object sender, SizeEventArgs event_arg)
        {
            listener(event_arg.NewSize);
        });
    }

    void Awake()
    {
        CubeInfrastructure infrastructure = new CubeInfrastructure();
        _usecase = new ScaleUsecase(infrastructure);
    }

    public void ResizeCube(float newSize)
    {
        _usecase.ResizeCube(newSize);
    }

    public float GetCubeSize()
    {
        return _usecase.GetCubeSize();
    }
}
