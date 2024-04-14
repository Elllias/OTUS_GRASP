using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Transform/Transform Synchronizer")]
    public sealed class UTransformSynchronizer : MonoBehaviour
    {
        [SerializeField]
        private Mode mode;

        [SerializeField]
        private Settings posititonSettings;

        [SerializeField]
        private Settings rotationSettings;

        private void Update()
        {
            if (this.mode == Mode.UPDATE)
            {
                this.SyncPositions();
                this.SyncRotations();
            }
        }

        private void FixedUpdate()
        {
            if (this.mode == Mode.FIXED_UPDATE)
            {
                this.SyncPositions();
                this.SyncRotations();
            }
        }

        private void LateUpdate()
        {
            if (this.mode == Mode.LATE_UPDATE)
            {
                this.SyncPositions();
                this.SyncRotations();
            }
        }

        private void SyncPositions()
        {
            if (!this.posititonSettings.enabled)
            {
                return;
            }
        
            var position = this.posititonSettings.source.position;
            var targets = this.posititonSettings.targets;
            
            for (int i = 0, count = targets.Length; i < count; i++)
            {
                var targetTransform = targets[i];
                targetTransform.position = position;
            }
        }

        private void SyncRotations()
        {
            if (!this.rotationSettings.enabled)
            {
                return;
            }
        
            var rotation = this.rotationSettings.source.rotation;
            var targets = this.rotationSettings.targets;
            
            for (int i = 0, count = targets.Length; i < count; i++)
            {
                var targetTransform = targets[i];
                targetTransform.rotation = rotation;
            }
        }

        private enum Mode
        {
            UPDATE,
            FIXED_UPDATE,
            LATE_UPDATE
        }

        [Serializable]
        private struct Settings
        {
            [SerializeField]
            public bool enabled;
        
            [SerializeField]
            public Transform source;

            [SerializeField]
            public Transform[] targets;
        } 
    }
}