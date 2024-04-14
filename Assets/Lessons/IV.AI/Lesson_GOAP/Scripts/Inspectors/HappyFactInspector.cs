using AI.GOAP;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class HappyFactInspector : FactInspector
    {
        [Header("World State")]
        [FactKey]
        [SerializeField]
        private string isHappy;

        public override void PopulateFacts(FactState state)
        {
            state.SetFact(this.isHappy, false);
        }
    }
}