using UnityEngine;

namespace Game.GameEngine
{
    [AddComponentMenu("GameEngine/Mechanics/Time/Timer Mechanics «Set Active Game Objects»")]
    public sealed class UTimerMechanics_SetActiveObjects : UTimerMechanics
    {
        [SerializeField]
        public bool setActive = true;

        [Space]
        [SerializeField]
        public GameObject[] objects;
        
        private void Awake()
        {
            this.SetActive(this.timer.IsPlaying);
        }

        protected override void OnTimerStarted()
        {
            this.SetActive(this.setActive);
        }

        protected override void OnTimerFinished()
        {
            this.SetActive(!this.setActive);
        }

        private void SetActive(bool isActive)
        {
            for (int i = 0, count = this.objects.Length; i < count; i++)
            {
                var obj = this.objects[i];
                obj.SetActive(isActive);
            }
        }
    }
}