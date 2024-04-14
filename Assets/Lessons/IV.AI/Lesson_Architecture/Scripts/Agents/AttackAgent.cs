using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    public sealed class AttackAgent : Agent
    {
        public IEntity Target
        {
            get { return this.target; }
        }
        
        [SerializeField]
        private MoveToPositionAgent moveAgent;

        [SerializeField]
        private MeleeCombatAgent meleeCombatAgent;

        [ShowInInspector, ReadOnly]
        private IEntity unit;

        [ShowInInspector, ReadOnly]
        private IEntity target;

        [ShowInInspector, ReadOnly]
        private float stoppingDistance;

        private Coroutine attackCoroutine;

        private IComponent_GetPosition unitComponent;
        private IComponent_GetPosition targetComponent;
        
        [Button]
        public void SetUnit(IEntity unit)
        {
            this.moveAgent.SetUnit(unit);
            this.meleeCombatAgent.SetUnit(unit);
            this.unit = unit;
            this.unitComponent = unit?.Get<IComponent_GetPosition>();
        }

        [Button]
        public void SetTarget(IEntity target)
        {
            this.meleeCombatAgent.SetTarget(target);
            this.target = target;
            this.targetComponent = target?.Get<IComponent_GetPosition>();
        }

        [Button]
        public void SetStoppingDistance(float stoppingDistance)
        {
            this.moveAgent.SetStoppingDistance(stoppingDistance);
            this.stoppingDistance = stoppingDistance;
        }

        protected override void OnStart()
        {
            this.attackCoroutine = this.StartCoroutine(this.AttackRoutine());
        }

        protected override void OnStop()
        {
            if (this.attackCoroutine != null)
            {
                this.StopCoroutine(this.attackCoroutine);
                this.attackCoroutine = null;
            }

            this.moveAgent.Stop();
            this.meleeCombatAgent.Stop();
        }

        private IEnumerator AttackRoutine()
        {
            var period = new WaitForFixedUpdate();

            while (true)
            {
                if (this.targetComponent != null && this.unitComponent != null)
                {
                    var unitPosition = this.unitComponent.Position;
                    var targetPosition = this.targetComponent.Position;

                    this.moveAgent.SetTargetPosiiton(targetPosition);
                    this.UpdateState(unitPosition, targetPosition);
                }
                else
                {
                    this.moveAgent.Stop();
                    this.meleeCombatAgent.Stop();
                }

                yield return period;
            }
        }

        private void UpdateState(Vector3 unitPosiiton, Vector3 targetPosition)
        {
            var distance = unitPosiiton - targetPosition;
            var distanceReached = distance.sqrMagnitude <= this.stoppingDistance * this.stoppingDistance;

            if (distanceReached)
            {
                if (this.moveAgent.IsPlaying)
                {
                    this.moveAgent.Stop();
                }

                if (!this.meleeCombatAgent.IsPlaying)
                {
                    this.meleeCombatAgent.Play();
                }
            }
            else
            {
                if (!this.moveAgent.IsPlaying)
                {
                    this.moveAgent.Play();
                }

                if (this.meleeCombatAgent.IsPlaying)
                {
                    this.meleeCombatAgent.Stop();
                }
            }
        }
    }
}