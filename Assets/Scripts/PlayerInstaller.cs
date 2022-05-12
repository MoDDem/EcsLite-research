using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform startPoint;
    public override void InstallBindings()
    {
        Container.Bind<PlayerInitSystem>()
            .AsSingle().WithArguments(prefab, startPoint);
    }
}