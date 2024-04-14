using System.Collections.Generic;
using AI.Iterators;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public sealed class CommandArgs_PatrolByPoints
    {
        public readonly IteratorMode patrolMode; 

        public readonly Vector3[] patrolPoints;

        public CommandArgs_PatrolByPoints(IteratorMode patrolMode, Vector3[] patrolPoints)
        {
            this.patrolMode = patrolMode;
            this.patrolPoints = patrolPoints;
        }
            
        public IEnumerator<Vector3> CreateIterator()
        {
            return IteratorFactory.CreateIterator(this.patrolMode, this.patrolPoints);
        }
    }
}