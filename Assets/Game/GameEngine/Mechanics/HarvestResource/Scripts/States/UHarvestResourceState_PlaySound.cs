using Elementary;
using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource State «Play Sound»")]
    public sealed class UHarvestResourceState_PlaySound : MonoState
    {
        [SerializeField]
        public MonoEmitter hitReceiver;

        [SerializeField]
        public UHarvestResourceOperator engine;

        [Space]
        [SerializeField]
        public AudioSource audioSource;
        
        [SerializeField]
        public AudioClip chopSFX;

        [SerializeField]
        public AudioClip mineSFX;

        public override void Enter()
        {
            this.hitReceiver.OnEvent += this.OnResourceHit;
        }

        public override void Exit()
        {
            this.hitReceiver.OnEvent -= this.OnResourceHit;
        }

        private void OnResourceHit()
        {
            var resourceType = this.engine.Current.targetResource
                .Get<IComponent_GetResourceType>()
                .Type;

            if (resourceType == ResourceType.WOOD)
            {
                this.audioSource.PlayOneShot(this.chopSFX);
            }
            else if (resourceType == ResourceType.STONE)
            {
                this.audioSource.PlayOneShot(this.mineSFX);
            }
        }
    }
}