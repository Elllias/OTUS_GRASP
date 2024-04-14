using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Alive/Component «Is Alive» (Bool Variable)")]
    public sealed class UComponent_IsAlive_BoolVariable : MonoBehaviour, IComponent_IsAlive
    {
        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        public bool IsAlive
        {
            get { return this.CheckIsAlive(); }
        }

        [SerializeField]
        private bool invert;

        [Space]
        [SerializeField]
        private MonoBoolVariable isAlive;

        private bool CheckIsAlive()
        {
            if (this.isAlive == null)
            {
                return default;
            }
            
            if (this.invert)
            {
                return !this.isAlive.Current;
            }

            return this.isAlive.Current;
        }
    }
}