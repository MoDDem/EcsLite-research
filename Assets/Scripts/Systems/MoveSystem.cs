using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MoveSystem : IEcsRunSystem
{
    [Inject] private readonly EcsWorld _world;
    
    public void Run(EcsSystems systems)
    {
        var filter = _world.Filter<MoveTag>().End();

        var playerPool = _world.GetPool<PlayerComponent>();
        var pointPool = _world.GetPool<PointComponent>();
        var timePool = _world.GetPool<TimeComponent>();

        ref var time = ref timePool.Get(0);
        
        foreach (var item in filter)
        {
            ref var player = ref playerPool.Get(item);
            ref var point = ref pointPool.Get(item);

            player.transform.LookAt(point.position);
            player.transform.position =
                Vector3.Lerp(player.transform.position, point.position, player.speed * time.DeltaTime);
            
            if((point.position - player.transform.position).sqrMagnitude < 0.001f)
            {
                var movePool = _world.GetPool<MoveTag>();
                movePool.Del(item);
            }
        }
    }
}