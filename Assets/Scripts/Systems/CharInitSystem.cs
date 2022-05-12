using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

public class CharInitSystem : IEcsInitSystem
{
    private readonly GameObject prefab;
    private Transform startPoint;

    public CharInitSystem(GameObject prefab, Transform sp)
    {
        this.prefab = prefab;
        startPoint = sp;
    }

    public void Init(EcsSystems systems)
    {
        var playerEntity = systems.GetWorld().NewEntity();
        
        var _characterPool = systems.GetWorld().GetPool<CharacterTag> ();
        ref var _ = ref _characterPool.Add (playerEntity);

        var playerInstance = Object.Instantiate(prefab, startPoint.position, Quaternion.identity);
        
        var posPool = systems.GetWorld().GetPool<PositionComponent> ();
        ref var c1 = ref posPool.Add (playerEntity);

        c1.transform = playerInstance.transform;
        c1.position = playerInstance.transform.position;
        c1.rotation = playerInstance.transform.rotation;
        
        var controllerPool = systems.GetWorld().GetPool<ControllerComponent> ();
        ref var c2 = ref controllerPool.Add (playerEntity);

        c2.controller = playerInstance.GetComponent<CharacterController>();
        c2.speed = 5f;
    }
}
