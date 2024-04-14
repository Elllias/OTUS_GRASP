using GameSystem;
using UnityEngine;

namespace Lessons.MetaGame.Lesson_Boosters
{
    public sealed class BoosterFactory : MonoBehaviour
    {
        [GameInject]
        private GameContext gameContext;
        
        public Booster CreateBooster(BoosterConfig config)
        {
            var booster = config.InstantiateBooster();
            GameInjector.Inject(this.gameContext, booster);
            return booster;
        }
    }
}