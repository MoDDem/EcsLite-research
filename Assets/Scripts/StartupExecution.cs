using System;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class StartupExecution : IDisposable, ITickable
{
    private EcsSystems _systems;
    private EcsWorld _world;

    public StartupExecution(EcsWorld ecsWorld, TimeService ts, GameObject prefab, Transform startPoint)
    {
        _systems = new EcsSystems(ecsWorld);
        _world = ecsWorld;

        _systems.Add(new TimeSystem(ts));
        _systems.Add(new CharInitSystem(prefab, startPoint));
        _systems.Add(new MoveSystem());
        
        _systems.Init();
    }
    
    public void Dispose()
    {
        _systems.Destroy();
        _systems.GetWorld()?.Destroy();
        _world.Destroy();

        _systems = null;
        _world = null;
    }

    public void Tick()
    {
        _systems.Run();
    }
}
