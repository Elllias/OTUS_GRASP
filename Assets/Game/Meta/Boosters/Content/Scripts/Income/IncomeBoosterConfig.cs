using UnityEngine;

namespace Game.Meta
{
    [CreateAssetMenu(
        fileName = "IncomeBoosterConfig",
        menuName = BoosterExtensions.MENU_PATH + "New IncomeBoosterConfig"
    )]
    public sealed class IncomeBoosterConfig : BoosterConfig
    {
        [Space]
        [SerializeField]
        public float incomeCoefficient = 2.0f;

        public override Booster InstantiateBooster()
        {
            return new IncomeBooster(this);
        }
    }
}