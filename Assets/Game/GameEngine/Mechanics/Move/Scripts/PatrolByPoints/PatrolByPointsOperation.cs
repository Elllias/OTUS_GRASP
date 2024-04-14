using System.Collections.Generic;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public sealed class PatrolByPointsOperation
    {
        public IEnumerable<Vector3> points;

        public PatrolByPointsOperation(IEnumerable<Vector3> points)
        {
            this.points = points;
        }
    }
}