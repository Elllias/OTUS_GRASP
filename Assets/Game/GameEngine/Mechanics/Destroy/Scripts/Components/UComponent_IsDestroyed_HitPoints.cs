using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Destroy/Component «Is Destroyed» (Hit Points)")]
    public sealed class UComponent_IsDestroyed_HitPoints : MonoBehaviour, IComponent_IsDestroyed
    {
        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        public bool IsDestroyed
        {
            get { return this.CheckIsDestroyed(); }
        }

        [Space]
        [SerializeField]
        private UHitPoints hitPointsEngine;

        private bool CheckIsDestroyed()
        {
            if (this.hitPointsEngine == null)
            {
                return default;
            }

            return this.hitPointsEngine.Current <= 0;
        }
    }
}