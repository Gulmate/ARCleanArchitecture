using VContainer;
using VContainer.Unity;

public class CubeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        //Register views where presenters will inject
        builder.RegisterComponentInHierarchy<CubeView>();
        builder.RegisterComponentInHierarchy<SizeSliderView>();
        builder.RegisterComponentInHierarchy<RedSliderView>();
        builder.RegisterComponentInHierarchy<GreenSliderView>();
        builder.RegisterComponentInHierarchy<BlueSliderView>();
        builder.RegisterComponentInHierarchy<AlphaSliderView>();
        builder.RegisterComponentInHierarchy<XRotSliderView>();
        builder.RegisterComponentInHierarchy<YRotSliderView>();
        builder.RegisterComponentInHierarchy<ZRotSliderView>();
        builder.RegisterComponentInHierarchy<CubeSaveView>();
        builder.RegisterComponentInHierarchy<CubeLoadView>();

        //Register presenters with keys while also register them as their implemented interfaces
        builder.RegisterComponentOnNewGameObject<ResizePresenter>(Lifetime.Scoped, "Resizepresenter").Keyed(PresenterType.Size).AsImplementedInterfaces(); ;
        builder.RegisterComponentOnNewGameObject<RecolorPresenter>(Lifetime.Scoped, "Recolorpresenter").Keyed(PresenterType.Color).AsImplementedInterfaces(); ;
        builder.RegisterComponentOnNewGameObject<RotationPresenter>(Lifetime.Scoped, "Rotationpresenter").Keyed(PresenterType.Rotation).AsImplementedInterfaces();
        builder.RegisterComponentOnNewGameObject<ButtonPresenter>(Lifetime.Scoped, "Buttonpresenter").Keyed(PresenterType.Button);//.AsImplementedInterfaces();

        builder.Register<CubeInfrastructure>(Lifetime.Singleton);
    }
}

//Enum for keys
public enum PresenterType
{
    Size,
    Color,
    Rotation,
    Button
}
