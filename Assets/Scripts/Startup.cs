using UnityEngine;
using Leopotam.EcsLite;

public class Startup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;
    private EcsSystems _updateSystems;
    private EcsSystems _fixedUpdateSystems;

    private void Start () {
        _world = new EcsWorld ();
        
        _systems = new EcsSystems (_world); //.Add (new WeaponSystem ());
        _updateSystems = new EcsSystems(_world);
        _fixedUpdateSystems = new EcsSystems(_world);

        _systems.Init ();
        _updateSystems.Init ();
        _fixedUpdateSystems.Init ();
    }

    private void Update ()  => _updateSystems?.Run ();
    private void FixedUpdate () => _fixedUpdateSystems?.Run ();

    private void OnDestroy () {
        if (_systems != null) {
            _systems.Destroy ();
            _systems = null;
        }
        
        if (_world != null) {
            _world.Destroy ();
            _world = null;
        }
        
        if (_updateSystems != null) {
            _updateSystems.Destroy ();
            _updateSystems = null;
        }
        
        if (_fixedUpdateSystems != null) {
            _fixedUpdateSystems.Destroy ();
            _fixedUpdateSystems = null;
        }
    }
}