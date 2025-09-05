using VContainer;
using VContainer.Unity;

public class CubeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        //Register views where presenters will inject
        builder.RegisterComponentInHierarchy<CubeView>();
        builder.RegisterComponentInHierarchy<SizeSliderView>();
        builder.RegisterComponentInHierarchy<ColorPanelView>();
        builder.RegisterComponentInHierarchy<RotatePanelView>();
        builder.RegisterComponentInHierarchy<ButtonView>();

        //Register presenters with keys while also register them as their implemented interfaces
        builder.RegisterComponentOnNewGameObject<ResizePresenter>(Lifetime.Scoped, "Resizepresenter").Keyed(PresenterType.Size);
        builder.RegisterComponentOnNewGameObject<RecolorPresenter>(Lifetime.Scoped, "Recolorpresenter").Keyed(PresenterType.Color) ;
        builder.RegisterComponentOnNewGameObject<RotationPresenter>(Lifetime.Scoped, "Rotationpresenter").Keyed(PresenterType.Rotation);
        builder.RegisterComponentOnNewGameObject<ButtonPresenter>(Lifetime.Scoped, "Buttonpresenter").Keyed(PresenterType.Button);

        builder.Register<CubeTransformator>(Lifetime.Singleton);
        builder.Register<CubeFileHandler>(Lifetime.Singleton);
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
