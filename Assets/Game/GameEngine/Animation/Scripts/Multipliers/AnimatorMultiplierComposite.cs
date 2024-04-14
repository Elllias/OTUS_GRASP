using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Game.GameEngine.Animation
{
    public sealed class AnimatorMultiplierComposite : IAnimatorMultiplier
    {
        [ShowInInspector, ReadOnly]
        private readonly List<IAnimatorMultiplier> multipliers = new();

        public void Add(IAnimatorMultiplier multiplier)
        {
            this.multipliers.Add(multiplier);
        }

        public void Remove(IAnimatorMultiplier multiplier)
        {
            this.multipliers.Remove(multiplier);
        }

        public float GetValue()
        {
            var result = 1.0f;
            for (int i = 0, count = this.multipliers.Count; i < count; i++)
            {
                result *= this.multipliers[i].GetValue();
            }

            return result;
        }
    }
}