using UnityEngine;

namespace Game.Gameplay.Player
{
    [CreateAssetMenu(
        fileName = "MoneyStorageConfig",
        menuName = "Gameplay/Player/New MoneyStorageConfig"
    )]
    public sealed class MoneyStorageConfig : ScriptableObject
    {
        public int InitialMoney
        {
            get { return this.initialMoney; }
        }

        [SerializeField]
        private int initialMoney;

        public static MoneyStorageConfig LoadAsset()
        {
            return Resources.Load<MoneyStorageConfig>(nameof(MoneyStorageConfig));
        }
    }
}