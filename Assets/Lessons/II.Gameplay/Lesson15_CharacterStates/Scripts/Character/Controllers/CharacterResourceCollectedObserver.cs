using Entities;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Player;
using GameSystem;
using Lessons.Character.Components;
using Lessons.Gameplay.Interaction;
using UnityEngine;

namespace Lessons.Character.Controllers
{
    public sealed class CharacterResourceCollectedObserver : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField]
        private MonoEntity character;

        [SerializeField]
        private ResourceStorage storage;

        private IGatherResourceComponent _gatherComponent;

        void IGameInitElement.InitGame()
        {
            _gatherComponent = character.Get<IGatherResourceComponent>();
            _gatherComponent.OnStopped += this.OnResourceCollected;
        }

        void IGameFinishElement.FinishGame()
        {
            _gatherComponent.OnStopped -= this.OnResourceCollected;
        }

        private void OnResourceCollected(GatherResourceCommand cmd)
        {
            if (!cmd.IsCompleted())
            {
                return;
            }
            
            //Destroy resource:
            cmd.Resource.Get<IComponent_Destoy>().Destroy();
            
            //Collect resources:
            var resourceType = cmd.Type;
            var count = cmd.Amount;
            this.storage.AddResource(resourceType, count);
            
            Debug.Log($"<color=green>Complete gathering {resourceType} {count}</color>");
        }
    }
}