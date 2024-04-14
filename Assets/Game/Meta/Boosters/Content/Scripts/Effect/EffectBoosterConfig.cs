using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.Meta
{
    [CreateAssetMenu(
        fileName = "EffectBoosterConfig",
        menuName = BoosterExtensions.MENU_PATH + "New EffectBoosterConfig"
    )]
    public sealed class EffectBoosterConfig : BoosterConfig
    {
        [Space]
        [SerializeField]
        public IEffect effect = new Effect();

        public override Booster InstantiateBooster()
        {
            return new EffectBooster(this);
        }
    }
}