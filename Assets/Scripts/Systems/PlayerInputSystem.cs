using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInputSystem : IEcsRunSystem
{
    [Inject] private EcsWorld _world;
    
    public void Run(EcsSystems systems)
    {
        if(!Mouse.current.leftButton.isPressed) return;

        var filter = _world.Filter<CharacterTag>().End();

        var pointPool = _world.GetPool<PointComponent>();
        var movePool = _world.GetPool<MoveTag>();
        
        foreach (var item in filter)
        {
            ref var point = ref pointPool.Get(item);

            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hit))
            {
                point.position = hit.point;
                
                if(movePool.Has(item)) return;
                var pool = _world.GetPool<MoveTag>();
                pool.Add(item);
            }
        }
    }
}