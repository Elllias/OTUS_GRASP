using UnityEngine;

namespace Lessons.MetaGame
{
    [CreateAssetMenu(
        fileName = "TimeRewardConfig",
        menuName = "Lessons/New TimeRewardConfig"
    )]
    public sealed class TimeRewardConfig : ScriptableObject
    {
        public float duration;
        public int moneyReward;
    }
}