using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;
    private Transform startPoint;
    public GameObject prefab;

    public PlayerInitSystem(GameObject prefab, Transform sp)
    {
        this.prefab = prefab;
        startPoint = sp;
        Debug.Log("init player");
    }

    public void Init(EcsSystems systems)
    {
        var playerEntity = systems.GetWorld().NewEntity();
        
        var _characterPool = systems.GetWorld().GetPool<CharacterTag> ();
        ref var _ = ref _characterPool.Add (playerEntity);

        var playerInstance = Object.Instantiate(prefab, startPoint.position, Quaternion.identity);
        
        var posPool = systems.GetWorld().GetPool<PlayerComponent> ();
        ref var c1 = ref posPool.Add (playerEntity);

        c1.transform = playerInstance.transform;
        c1.speed = 2f;
        
        var pointPool = systems.GetWorld().GetPool<PointComponent> ();
        ref var c2 = ref pointPool.Add (playerEntity);

        c2.position = playerInstance.transform.position;
    }
}
