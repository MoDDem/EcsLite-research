using Leopotam.EcsLite;
using Zenject;

public class Startup : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(new EcsWorld());

        //Container.Bind<HelloWorldSystem>().AsSingle();

        Container.BindInterfacesAndSelfTo<StartupExecution>()
            .AsSingle()
            .NonLazy();
    }
}