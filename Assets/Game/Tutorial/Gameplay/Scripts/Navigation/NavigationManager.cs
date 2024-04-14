using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Tutorial.Gameplay
{
    public sealed class NavigationManager : MonoBehaviour,
        IGameConstructElement,
        IGameInitElement
    {
        [SerializeField]
        private NavigationArrow arrow;

        private IComponent_GetPosition heroComponent;

        private IHeroService heroService;

        [PropertySpace]
        [ReadOnly]
        [ShowInInspector]
        private Vector3 targetPosition;

        [ReadOnly]
        [ShowInInspector]
        private bool isActive;

        private void Awake()
        {
            this.arrow.Hide();
        }

        private void Update()
        {
            if (this.isActive)
            {
                this.arrow.SetPosition(this.heroComponent.Position);
                this.arrow.LookAt(this.targetPosition);
            }
        }
        
        [Button]
        public void StartLookAt(Transform targetPoint)
        {
            this.StartLookAt(targetPoint.position);
        }

        public void StartLookAt(Vector3 targetPosition)
        {
            this.arrow.Show();
            this.isActive = true;
            this.targetPosition = targetPosition;
        }

        public void Stop()
        {
            this.arrow.Hide();
            this.isActive = false;
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.heroService = context.GetService<HeroService>();
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_GetPosition>();
        }
    }
}