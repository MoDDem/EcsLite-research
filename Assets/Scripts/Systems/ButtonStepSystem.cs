using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class ButtonStepSystem : IEcsRunSystem
{
    [Inject] private readonly EcsWorld _world;
    
    public void Run(EcsSystems systems)
    {
        var filter = _world.Filter<ChainableComponent>().End();
        var filterPlayer = _world.Filter<PlayerComponent>().End();
        
        var chainPool = _world.GetPool<ChainableComponent>();

        var playerPool = _world.GetPool<PlayerComponent>();
        var buttonPool = _world.GetPool<ButtonComponent>();
        
        var openTagPool = _world.GetPool<OpenDoorTag>();

        foreach (var playerID in filterPlayer)
        {
            ref var player = ref playerPool.Get(playerID);
            
            foreach (var item in filter)
            {
                ref var button = ref buttonPool.Get(item);
                ref var chain = ref chainPool.Get(item);
                var packed = chain.entity;

                if (packed.Unpack(_world, out var unpacked))
                {
                    if(Vector3.Distance(player.transform.position, button.position) > button.radius)
                    {
                        openTagPool.Del(unpacked);
                        openTagPool.Del(item);
                        continue;
                    }
                    
                    if(openTagPool.Has(item)) continue;
                    
                    openTagPool.Add(unpacked);
                    openTagPool.Add(item);
                }
            }
        }
    }
}