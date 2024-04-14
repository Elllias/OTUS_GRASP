using UnityEngine;

namespace GameSystem
{
    ///FOR ADVANCED GAME ARCHITECTURE
    [CreateAssetMenu(
        fileName = "GameInjectTask",
        menuName = "GameSystem/New GameInjectTask"
    )]
    public sealed class GameInjectTask : GameContext.ConstructTask
    {
        [SerializeField]
        private bool injectElements = true;

        [SerializeField]
        private bool injectServices = true;
        
        public override void Construct(GameContext gameContext)
        {
            if (this.injectElements)
            {
                GameInjector.InjectAll(gameContext, gameContext.GetAllElements());
            }

            if (this.injectServices)
            {
                GameInjector.InjectAll(gameContext, gameContext.GetAllServices());
            }
        }
    }
}