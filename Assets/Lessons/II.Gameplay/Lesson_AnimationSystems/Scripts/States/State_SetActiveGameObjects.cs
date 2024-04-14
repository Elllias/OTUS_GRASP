using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class State_SetActiveGameObjects : MonoState
    {
        [SerializeField]    
        private GameObject[] gameObjects;

        private void Awake()
        {
            this.SetActiveObjects(false);
        }

        public override void Enter()
        {
            this.SetActiveObjects(true);
        }

        public override void Exit()
        {
            this.SetActiveObjects(false);
        }

        private void SetActiveObjects(bool isActive)
        {
            for (int i = 0, count = this.gameObjects.Length; i < count; i++)
            {
                var gameObject = this.gameObjects[i];
                gameObject.SetActive(isActive);
            }
        }
    }
}