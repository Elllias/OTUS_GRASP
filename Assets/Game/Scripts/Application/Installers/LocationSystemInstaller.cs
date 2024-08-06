using Game.Scripts.Application.LocationSystem;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public class LocationSystemInstaller : MonoInstaller
    {
        [SerializeField] private LocationTrigger[] _locationTriggers;
        [SerializeField] private Transform _worldTransform;
        
        public override void InstallBindings()
        {
            Container.Bind<LocationSystem>().AsSingle().WithArguments(_locationTriggers, _worldTransform).NonLazy();
        }
    }
}