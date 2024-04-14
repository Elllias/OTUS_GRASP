using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public abstract class LevelVisualBase : MonoBehaviour
    {
        public abstract void Activate();
        
        public abstract void SetActive(bool isVisible);
    }
}