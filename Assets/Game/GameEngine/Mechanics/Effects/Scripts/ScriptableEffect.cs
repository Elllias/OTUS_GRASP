using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [CreateAssetMenu(
        fileName = "ScriptableEffect",
        menuName = "GameEngine/Mechanics/Effects/New ScriptableEffect"
    )]
    public sealed class ScriptableEffect : SerializedScriptableObject, IEffect
    {
        [SerializeField]
        private IEffectParameter[] parameters = new IEffectParameter[0];

        private Effect effect;

        public T GetParameter<T>(EffectId name)
        {
            return this.effect.GetParameter<T>(name);
        }

        public bool TryGetParameter<T>(EffectId name, out T value)
        {
            return this.effect.TryGetParameter(name, out value);
        }

        protected override void OnAfterDeserialize()
        {
            base.OnAfterDeserialize();
            this.effect = new Effect(this.parameters);
        }
    }
}