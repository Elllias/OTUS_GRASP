using Elementary;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Destroy/Component «Can Destroy» (Bool Variable)")]
    public sealed class UComponent_CanDestroy_BoolVariable : MonoBehaviour, IComponent_CanDestroy
    {
        [FormerlySerializedAs("activeController")]
        [SerializeField]
        private MonoBoolVariable isAlive;

        public bool CanDestroy()
        {
            return this.isAlive.Current;
        }
    }
}