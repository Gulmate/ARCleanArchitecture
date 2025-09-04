using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

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

    /*public void Execute<T>(T data)
    {
        throw new NotImplementedException();
    }

    public void onChange()
    {
        throw new NotImplementedException();
    }

    public T Get<T>()
    {
        throw new NotImplementedException();
    }*/
}


/*public class ResizePresenter : IStartable, IDisposable
{
    private readonly CubeService _service;
    private readonly SizeModel _model;

    public ResizePresenter(CubeService newService, SizeModel model)
    {
        _service = newService;
        _model = model;
    }

    public void Start()
    {
        _model.slider.onValueChanged.AddListener(Print);
    }

    public void Dispose()
    {
        _model.slider.onValueChanged.RemoveListener(Print);
    }

    private void Print(float value) => _service.LogCubeSize(value);
}

[RequireComponent(typeof(SizeModel))]
public class LifetimeScopeExample : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<CubeService>(Lifetime.Singleton);
        builder.RegisterEntryPoint<ResizePresenter>();
        builder.RegisterComponent(GetComponent<SizeModel>());
    }
}*/