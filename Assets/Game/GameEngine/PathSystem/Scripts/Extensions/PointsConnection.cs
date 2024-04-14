using System;
using UnityEngine;

namespace Game.GameEngine.PathSystem
{
    [Serializable]
    public sealed class PointsConnection
    {
        [SerializeField]
        public Point[] connectedPoints = new Point[0];
    }
}