using System;
using Elementary;
using Lessons.Architecture.Declarative.Mechanics;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Declarative
{
    [Serializable]
    public sealed class HeroModel_Life
    {
        [SerializeField]
        public IntVariable hitPoints = new();

        [ShowInInspector]
        public Emitter<int> takeDamageEvent = new();

        [ShowInInspector]
        public Emitter deathEvent = new();

        private readonly HitPointsMechanics_Death hitPointsMechanics = new();

        [Construct]
        private void ConstructHitPoints(HeroModel model)
        {
            this.hitPoints.Current = model.config.hitPoints;
            this.hitPointsMechanics.Construct(this.hitPoints, this.deathEvent);
        }

        [Construct]
        private void ConstructTakeDamage()
        {
            this.takeDamageEvent.AddListener(damage => this.hitPoints.Current -= damage);
        }

        [Construct]
        private void ConstructDeath()
        {
            this.deathEvent.AddListener(() => Debug.Log("Hero was destroyed!"));
        }
    }
}