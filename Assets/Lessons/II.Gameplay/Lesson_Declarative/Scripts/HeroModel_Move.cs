using System;
using Elementary;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Declarative
{
    [Serializable]
    public sealed class HeroModel_Move
    {
        [ShowInInspector]
        public Emitter<Vector3> moveEvent = new();

        [SerializeField]
        private Transform moveTransform;

        [Construct]
        private void Construct()
        {
            this.moveEvent.AddListener(vector => this.moveTransform.position += vector);
        }
    }
}