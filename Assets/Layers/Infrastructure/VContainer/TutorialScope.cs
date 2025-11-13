using VContainer;
using VContainer.Unity;

public class TutorialScope: LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<TutorialView>();

        builder.RegisterComponentOnNewGameObject<TutorialPresenter>(Lifetime.Scoped, "TutorialPresenter");
    }
}
