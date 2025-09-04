using VContainer;
using VContainer.Unity;

public class CubeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<CubeView>();
        builder.RegisterComponentInHierarchy<SizeSliderView>();
        builder.RegisterComponentInHierarchy<RedSliderView>();
        builder.RegisterComponentInHierarchy<GreenSliderView>();
        builder.RegisterComponentInHierarchy<BlueSliderView>();
        builder.RegisterComponentInHierarchy<AlphaSliderView>();
        builder.RegisterComponentInHierarchy<XRotSliderView>();
        builder.RegisterComponentInHierarchy<YRotSliderView>();
        builder.RegisterComponentInHierarchy<ZRotSliderView>();
        builder.RegisterComponentOnNewGameObject<ResizePresenter>(Lifetime.Scoped, "Resizepresenter").Keyed(PresenterType.Size).AsImplementedInterfaces(); ;
        builder.RegisterComponentOnNewGameObject<RecolorPresenter>(Lifetime.Scoped, "Recolorpresenter").Keyed(PresenterType.Color).AsImplementedInterfaces(); ;
        builder.RegisterComponentOnNewGameObject<RotationPresenter>(Lifetime.Scoped, "Rotationpresenter").Keyed(PresenterType.Rotation).AsImplementedInterfaces();
    }
}

public enum PresenterType
{
    Size,
    Color,
    Rotation
}
