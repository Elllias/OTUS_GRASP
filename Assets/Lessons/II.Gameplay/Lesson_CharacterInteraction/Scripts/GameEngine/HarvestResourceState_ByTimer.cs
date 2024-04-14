using System.Collections;
using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.Lesson_CharacterInteraction
{
    public sealed class HarvestResourceState_ByTimer : MonoStateCoroutine
    {
        [SerializeField]
        private HarvestResourceEngine engine;

        [SerializeField]
        private FloatAdapter duration;
        
        protected override IEnumerator Do()
        {
            yield return new WaitForSeconds(this.duration.Current);
            this.engine.CurrentOperation.isCompleted = true;
            this.engine.StopHarvest();
        }
    }
}