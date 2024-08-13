using Game.Scripts.Application.Configs;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Application.Installers
{
    [CreateAssetMenu(menuName = "Configs/Installers/New UiAssetConfigInstaller", fileName = "UiAssetConfigInstaller", order = 0)]
    public class UiAssetConfigInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private UiAssetConfig _config;
        
        public override void InstallBindings()
        {
            Container.Bind<UiAssetConfig>().FromInstance(_config).AsSingle();
        }
    }
}