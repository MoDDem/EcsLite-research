using System;
using Leopotam.EcsLite;
using Zenject;

public class StartupExecution : IDisposable, ITickable
{
    private readonly EcsSystems _systems;
    private EcsWorld _world;

    public StartupExecution(EcsWorld ecsWorld)
    {
        _systems = new EcsSystems(ecsWorld);
        _world = ecsWorld;

        //_systems.Add(helloWorldSystem);
        
        _systems.Init();
    }
    
    public void Dispose()
    {
        _systems.Destroy();
        _world.Destroy();
    }

    public void Tick()
    {
        _systems.Run();
    }

    public void FixedTick()
    {
        throw new NotImplementedException();
    }
}
