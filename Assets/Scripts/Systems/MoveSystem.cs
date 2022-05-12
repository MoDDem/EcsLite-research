using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSystem : IEcsRunSystem
{
    public void Run(EcsSystems systems)
    {
        if(!Mouse.current.leftButton.isPressed) return;
        
        var world = systems.GetWorld();
        
        var filter = world.Filter<CharacterTag>().End();

        var posPool = world.GetPool<PositionComponent>();
        var controlPool = world.GetPool<ControllerComponent>();
        
        foreach (var item in filter)
        {
            ref var pos = ref posPool.Get(item);
            ref var control = ref controlPool.Get(item);
            
            pos.transform.position += Vector3.forward * control.speed * Time.deltaTime;
        }
    }
}