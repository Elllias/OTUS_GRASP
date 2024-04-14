using UnityEngine;

namespace Lessons.MetaGame.Lesson_Boosters
{
    public abstract class BoosterConfig : ScriptableObject
    {
        [SerializeField]
        public string id;

        [SerializeField]
        public float durationSeconds;

        [SerializeField]
        public int moneyPrice;

        public abstract Booster InstantiateBooster();
    }
}