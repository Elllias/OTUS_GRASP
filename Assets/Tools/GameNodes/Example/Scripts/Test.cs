using Game.GameEngine;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameNodes
{
    public sealed class Test : MonoBehaviour
    {
        [SerializeField]
        private GameContext gameContext;
        
        [Button]
        public void TakeDamage(int damage)
        {
            this.gameContext
                .Node<PlayerContext>(it => it.name == "PlayerSys1")
                .Service<HeroService>()
                .GetHero()
                .Get<IComponent_TakeDamage>()
                .TakeDamage(new TakeDamageArgs(damage, TakeDamageReason.UNDEFINED));
        }
    }
}