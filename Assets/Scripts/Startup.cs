using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class Startup : MonoInstaller
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform startPoint;
    
    public override void InstallBindings()
    {
        Container.BindInstance(new EcsWorld());
        Container.BindInstance(new TimeService());
        Container.BindInstance(prefab);
        Container.BindInstance(startPoint);

        Container.BindInterfacesAndSelfTo<StartupExecution>()
            .AsSingle()
            .NonLazy();
    }
}