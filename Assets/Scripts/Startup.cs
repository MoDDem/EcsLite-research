using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class Startup : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<StartupExecution>()
            .AsSingle()
            .NonLazy();
        
        BindWorlds();
        BindSystems();
    }

    private void BindSystems()
    {
        Container.Bind<TimeSystem>().AsSingle();
        Container.Bind<PlayerInputSystem>().AsSingle();
        Container.Bind<MoveSystem>().AsSingle();
        Container.Bind<ButtonStepSystem>().AsSingle();
        Container.Bind<OpenDoorSystem>().AsSingle();
    }

    private void BindWorlds()
    {
        Container.BindInstance(new EcsWorld()).AsSingle();
    }
}