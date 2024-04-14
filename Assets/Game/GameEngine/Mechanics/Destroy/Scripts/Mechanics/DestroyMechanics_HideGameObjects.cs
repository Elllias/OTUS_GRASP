using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class DestroyMechanics_HideGameObjects : DestroyMechanics
    {
        [SerializeField]
        public GameObject[] gameObjects;
        
        protected override void Destroy(DestroyArgs destroyArgs)
        {
            for (int i = 0, count = this.gameObjects.Length; i < count; i++)
            {
                var gameObject = this.gameObjects[i];
                gameObject.SetActive(false);
            }
        }
    }
}