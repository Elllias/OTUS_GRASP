using System;
using Entities;
using Declarative;
using UnityEngine;

namespace Lessons.Architecture.Declarative
{
    [Serializable]
    public sealed class HeroModel_Components
    {
        [SerializeField]
        private MonoEntityStd entity;

        [Construct]
        private void Construct(HeroModel_Life life, HeroModel_Move move)
        {
            this.entity.Add(new TakeDamageComponent(life.takeDamageEvent));
            this.entity.Add(new MoveComponent(move.moveEvent));
        }
    }
}