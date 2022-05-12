
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class TimeSystem : IEcsRunSystem
{
    private TimeService _ts;

    public TimeSystem(TimeService ts)
    {
        _ts = ts;
        Debug.Log("inject");
    }
    
    public void Run(EcsSystems systems)
    {
        _ts.Time = Time.time;
        _ts.UnscaledTime = Time.unscaledTime;
        _ts.DeltaTime = Time.deltaTime;
        _ts.UnscaledDeltaTime = Time.unscaledDeltaTime;
    }
}