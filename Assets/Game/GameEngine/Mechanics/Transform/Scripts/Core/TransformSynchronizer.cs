using System;
using Declarative;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class TransformSynchronizer :
        IUpdateListener,
        IFixedUpdateListener,
        ILateUpdateListener
    {
        public Mode mode;

        public bool isEnabled;

        [Space]
        public Transform sourcePosition;

        public Transform[] syncPosiitions;

        [Space]
        public Transform sourceRotation;
        
        public Transform[] syncRotations;

        void IUpdateListener.Update(float deltaTime)
        {
            if (this.isEnabled && this.mode == Mode.UPDATE)
            {
                this.SyncPositions();
                this.SyncRotations();
            }
        }

        void IFixedUpdateListener.FixedUpdate(float deltaTime)
        {
            if (this.isEnabled && this.mode == Mode.FIXED_UPDATE)
            {
                this.SyncPositions();
                this.SyncRotations();
            }
        }

        void ILateUpdateListener.LateUpdate(float deltaTime)
        {
            if (this.isEnabled && this.mode == Mode.LATE_UPDATE)
            {
                this.SyncPositions();
                this.SyncRotations();
            }
        }

        private void SyncPositions()
        {
            
            var position = this.sourcePosition.position;
            for (int i = 0, count = this.syncPosiitions.Length; i < count; i++)
            {
                var targetTransform = this.syncPosiitions[i];
                targetTransform.position = position;
            }
        }

        private void SyncRotations()
        {
            var rotation = this.sourceRotation.rotation;
            for (int i = 0, count = this.syncRotations.Length; i < count; i++)
            {
                var targetTransform = this.syncRotations[i];
                targetTransform.rotation = rotation;
            }
        }

        public enum Mode
        {
            UPDATE = 0,
            FIXED_UPDATE = 1,
            LATE_UPDATE = 2
        }
    }
}