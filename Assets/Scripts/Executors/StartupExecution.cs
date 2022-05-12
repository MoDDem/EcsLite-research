using System;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class StartupExecution : IDisposable, ITickable, IInitializable
{
    private EcsSystems _systems;
    private EcsWorld _world;

    public StartupExecution(EcsWorld ecsWorld, TimeSystem ts, 
        PlayerInitSystem ps, PlayerInputSystem pis, MoveSystem ms)
    {
        _world = ecsWorld;
        _systems = new EcsSystems(_world)
            .Add(ts)
            .Add(ps)
            .Add(pis)
            .Add(ms);
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

    public void Initialize()
    {
        _systems.Init();
    }
}
