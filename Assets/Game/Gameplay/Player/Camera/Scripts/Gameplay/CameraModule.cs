using System.Collections.Generic;
using Cinemachine;
using Game.Gameplay.Hero;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class CameraModule : GameModule
    {
        [SerializeField]
        private CinemachineVirtualCamera virtualCamera;

        private readonly CinemachineCameraController cameraController = new();

        private void Awake()
        {
            this.virtualCamera.enabled = false;
        }

        public override IEnumerable<IGameElement> GetElements()
        {
            yield return this.cameraController;
        }

        public override IEnumerable<object> GetServices()
        {
            yield break;
        }

        public override void ConstructGame(GameContext context)
        {
            var heroService = context.GetService<HeroService>();
            this.cameraController.Construct(this.virtualCamera, heroService);
        }
    }
}