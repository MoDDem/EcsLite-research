using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class InteractableInitSystem : IEcsInitSystem
{
    [Inject] private readonly List<GameObject> buttons;
    [Inject] private readonly List<GameObject> doors;
    [Inject] private readonly EcsWorld _world;

    private int id = 0;
    
    public void Init(EcsSystems systems)
    {
        var chainPool = _world.GetPool<ChainableComponent>();
        var buttonPool = _world.GetPool<ButtonComponent>();
        var doorPool = _world.GetPool<DoorComponent>();

        for (int i = 0; i < buttons.Count; i++)
        {
            var buttonEntity = _world.NewEntity ();
            var doorEntity = _world.NewEntity ();
            
            var packed = _world.PackEntity(doorEntity);
            
            ref var chain = ref chainPool.Add(buttonEntity);
            chain.entity = packed;
            
            ref var button = ref buttonPool.Add(buttonEntity);
            ref var door = ref doorPool.Add(doorEntity);

            button.position = buttons[i].transform.position;
            button.radius = 0.6f;

            door.transform = doors[i].transform;
            door.startPosition = doors[i].transform.localPosition;
            door.offset = 1.8f;
        }
    }
}