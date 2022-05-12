
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class OpenDoorSystem : IEcsRunSystem
{
    [Inject] private EcsWorld _world;
    
    public void Run(EcsSystems systems)
    {
        var filter = _world.Filter<OpenDoorTag>().Inc<DoorComponent>().End();
        
        var doorPool = _world.GetPool<DoorComponent>();
        var openTagPool = _world.GetPool<OpenDoorTag>();
        
        foreach (var item in filter)
        {
            ref var door = ref doorPool.Get(item);
            var pos = door.transform.localPosition;
            var startPos = door.startPosition;
            
            door.transform.localPosition = Vector3.Lerp(pos, new Vector3(startPos.x, startPos.y, startPos.z+ door.offset),
                0.3f * Time.deltaTime);
            
            if(Vector3.Distance(pos, startPos) >= door.offset)
                openTagPool.Del(item);
        }
    }
}