using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Destroy/Component «Is Destroyed» (Bool Variable)")]
    public sealed class UComponent_IsDestroyed_BoolVariable : MonoBehaviour, IComponent_IsDestroyed
    {
        public bool IsDestroyed
        {
            get { return this.CheckDestroyed(); }
        }

        [SerializeField]
        private bool invert;
        
        [SerializeField]
        private MonoBoolVariable isDestroyed;

        private bool CheckDestroyed()
        {
            if (this.invert)
            {
                return this.isDestroyed.Current;
            }
            
            return this.isDestroyed.Current;
        }
    }
}