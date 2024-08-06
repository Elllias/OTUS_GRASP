using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private CameraConfig cameraConfig;

        [SerializeField]
        private new Camera camera;
        
        [SerializeField]
        private InputConfig inputConfig;

        public override void InstallBindings()
        {
            this.Container
                .Bind<Camera>()
                .FromInstance(this.camera);

            this.Container
                .Bind<ICharacter>()
                .FromComponentInHierarchy()
                .AsSingle();

            this.Container
                .BindInterfacesTo<MoveController>()
                .AsCached()
                .NonLazy();
            
            this.Container
                .Bind<IMoveInput>()
                .To<MoveInput>()
                .AsSingle()
                .WithArguments(this.inputConfig)
                .NonLazy();

            this.Container
                .BindInterfacesTo<CameraFollower>()
                .AsCached()
                .WithArguments(this.cameraConfig.cameraOffset)
                .NonLazy();
        }
    }
}