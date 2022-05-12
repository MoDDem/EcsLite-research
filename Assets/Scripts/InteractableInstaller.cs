using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InteractableInstaller : MonoInstaller
{
    //order is important!
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private List<GameObject> doors;
    
    public override void InstallBindings()
    {
        Container.Bind<InteractableInitSystem>()
            .AsSingle().WithArguments(buttons, doors);
    }
}