using VContainer;
using VContainer.Unity;

public class ConnectionScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<SessionView>();

        builder.Register<SessionPresenter>(Lifetime.Scoped).AsSelf();
    }
}
