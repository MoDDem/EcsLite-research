
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class TimeSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsWorld _world;

    public TimeSystem(EcsWorld world)
    {
        _world = world;
        Debug.Log("inject");
    }
    
    public void Run(EcsSystems systems)
    {
        var pool = _world.GetPool<TimeComponent>();
        var filter = _world.Filter<TimeComponent>().End();
        foreach (var item in filter)
        {
            ref var ts = ref pool.Get(item);
            
            ts.Time = Time.time;
            ts.UnscaledTime = Time.unscaledTime;
            ts.DeltaTime = Time.deltaTime;
            ts.UnscaledDeltaTime = Time.unscaledDeltaTime;
        }
    }

    public void Init(EcsSystems systems)
    {
        
        var entity = _world.NewEntity();
        var pool = _world.GetPool<TimeComponent>();
        pool.Add(entity);
    }
}