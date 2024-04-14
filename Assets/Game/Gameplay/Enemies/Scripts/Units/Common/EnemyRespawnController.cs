using System;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class EnemyRespawnController :
        IGameReadyElement,
        IGameFinishElement
    {
        [ShowInInspector, ReadOnly]
        private IEntity unit;

        [ShowInInspector, ReadOnly]
        private IEntity ai;

        [ShowInInspector, ReadOnly]
        private Timer timer = new();

        [ShowInInspector, ReadOnly]
        private Transform respawnPoint;

        public void Construct(IEntity unit, IEntity ai, float respawnTime, Transform respawnPoint)
        {
            this.unit = unit;
            this.ai = ai;
            this.timer.Duration = respawnTime;
            this.respawnPoint = respawnPoint;
        }

        void IGameReadyElement.ReadyGame()
        {
            this.unit.Get<IComponent_OnDestroyed<DestroyArgs>>().OnDestroyed += this.OnDestroyed;
            this.timer.OnFinished += this.OnTimerFinished;
        }

        void IGameFinishElement.FinishGame()
        {
            this.unit.Get<IComponent_OnDestroyed<DestroyArgs>>().OnDestroyed -= this.OnDestroyed;
            this.timer.OnFinished -= this.OnTimerFinished;
            this.timer.Stop();
        }

        private void OnDestroyed(DestroyArgs destroyArgs)
        {
            this.DisableAI();
            this.StartTimer();
        }

        private void DisableAI()
        {
            this.ai.Get<IComponent_Enable>().SetEnable(false);
        }

        private void StartTimer()
        {
            this.timer.Stop();
            this.timer.ResetTime();
            this.timer.Play();
        }

        private void OnTimerFinished()
        {
            this.RespawnEntity();
        }

        private void RespawnEntity()
        {
            this.ResetPosition();
            this.ResetRotation();
            this.DoRespawn();
            this.EnableAI();
        }

        private void ResetPosition()
        {
            var positionComponent = this.unit.Get<IComponent_SetPosition>();
            positionComponent.SetPosition(this.respawnPoint.position);
        }

        private void ResetRotation()
        {
            var rotationComponent = this.unit.Get<IComponent_SetRotation>();
            rotationComponent.SetRotation(this.respawnPoint.rotation);
        }

        private void DoRespawn()
        {
            this.unit.Get<IComponent_Respawn>().Respawn();
        }
        
        private void EnableAI()
        {
            this.ai.Get<IComponent_Enable>().SetEnable(true);
        }
    }
}