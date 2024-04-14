using System;
using Declarative;
using UnityEngine;

namespace Lessons.Utils
{
    [Serializable]
    public sealed class TransformSynchronizer : IUpdateListener
    {
        [SerializeField]
        private Transform source;

        [SerializeField]
        private Transform[] targets;

        void IUpdateListener.Update(float deltaTime)
        {
            var position = this.source.position;
            var rotation = this.source.rotation;
            foreach (var target in this.targets)
            {
                target.position = position;
                target.rotation = rotation;
            }
        }
    }
}