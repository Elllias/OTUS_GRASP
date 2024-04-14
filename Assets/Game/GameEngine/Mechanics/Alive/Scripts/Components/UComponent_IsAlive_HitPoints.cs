using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Alive/Component «Is Alive» (Hit Points)")]
    public sealed class UComponent_IsAlive_HitPoints : MonoBehaviour, IComponent_IsAlive
    {
        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        public bool IsAlive
        {
            get { return this.CheckIsAlive(); }
        }

        [Space]
        [SerializeField]
        private UHitPoints hitPointsEngine;

        private bool CheckIsAlive()
        {
            if (this.hitPointsEngine == null)
            {
                return default;
            }

            return this.hitPointsEngine.Current > 0;
        }
    }
}