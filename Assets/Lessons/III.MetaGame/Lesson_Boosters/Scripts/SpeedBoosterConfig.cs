using UnityEngine;

namespace Lessons.MetaGame.Lesson_Boosters
{
    [CreateAssetMenu(
        fileName = "Speed Booster",
        menuName = "Lessons/New Speed Booster"
    )]
    public sealed class SpeedBoosterConfig : BoosterConfig
    {
        [SerializeField]
        public float speedMultiplier;
    
        public override Booster InstantiateBooster()
        {
            return new SpeedBooster(this);
        }
    }
}