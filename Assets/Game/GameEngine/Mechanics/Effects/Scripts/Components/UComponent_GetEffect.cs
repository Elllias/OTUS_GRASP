using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Effects/Component «Get Effect»")]
    public sealed class UComponent_GetEffect : SerializedMonoBehaviour, IComponent_GetEffect
    {
        public IEffect Effect
        {
            get { return this.effect; }
        }
        
        [SerializeField]
        private IEffect effect;
    }
}