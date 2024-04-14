using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using UnityEngine;

namespace GameNodes
{
    public sealed class MoveController
    {
        private IMoveInput input;

        private IComponent_MoveInDirection heroComponent;

        [GameInit]
        public void Init(IHeroService heroService, IMoveInput input)
        {
            this.heroComponent = heroService.GetHero().Get<IComponent_MoveInDirection>();
            this.input = input;
        }

        [GameStart]
        public void Enable()
        {
            this.input.OnMoved += this.OnDirectionMoved;
        }

        [GameFinish]
        public void Disable()
        {
            this.input.OnMoved -= this.OnDirectionMoved;
        }

        private void OnDirectionMoved(Vector2 screenDirection)
        {
            var worldDirection = new Vector3(screenDirection.x, 0.0f, screenDirection.y);
            this.heroComponent.Move(worldDirection);
        }
    }
}