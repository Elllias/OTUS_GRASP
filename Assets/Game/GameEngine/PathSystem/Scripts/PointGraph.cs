using System.Collections.Generic;
using PathFinding;
using UnityEditor;
using UnityEngine;

namespace Game.GameEngine.PathSystem
{
    public abstract class PointGraph : MonoBehaviour
    {
        private readonly List<Point> buffer;

        private readonly PathFinder<Point> pathFinder;

        public PointGraph()
        {
            this.pathFinder = new PointPathFinder(this);
            this.buffer = new List<Point>();
        }

        public bool FindPath(Vector3 startPosition, Vector3 endPosition, List<Vector3> path)
        {
            if (!this.FindClosestPoint(startPosition, out var startPoint))
            {
                Debug.LogWarning("Start point is not found!");
                return false;
            }

            if (!this.FindClosestPoint(endPosition, out var endPoint))
            {
                Debug.LogWarning("End point is not found!");
                return false;
            }

            if (!this.FindPath(startPoint, endPoint, this.buffer))
            {
                Debug.LogWarning($"Path between points {startPoint.name}, {endPoint.name} is not found!");
                return false;
            }

            path.Clear();
            path.Add(startPosition);

            for (int i = 0, count = this.buffer.Count; i < count; i++)
            {
                var point = this.buffer[i];
                path.Add(point.WorldPosition);
            }

            path.Add(endPosition);
            return true;
        }

        public bool FindPath(Point startPoint, Point endPoint, List<Point> path)
        {
            if (!this.pathFinder.FindPath(startPoint, endPoint, path))
            {
                Debug.LogWarning($"Path between points {startPoint.name}, {endPoint.name} is not found!");
                return false;
            }

            return true;
        }

        public bool FindClosestPoint(Vector3 position, out Point result)
        {
            result = null;
            var minDistance = -1.0f;

            var pathPoints = this.GetAllPoints();
            foreach (var point in pathPoints)
            {
                var distanceToPoint = point.GetDistanceTo(position);
                if (ReferenceEquals(result, null) || minDistance > distanceToPoint)
                {
                    result = point;
                    minDistance = distanceToPoint;
                }
            }

            return !ReferenceEquals(result, null);
        }

        protected abstract IEnumerable<Point> GetAllPoints();

        protected abstract IEnumerable<Point> GetNeighbours(Point point);

        private sealed class PointPathFinder : PathFinder<Point>
        {
            private readonly PointGraph graph;

            public PointPathFinder(PointGraph graph)
            {
                this.graph = graph;
            }

            protected override IEnumerable<Point> GetNeighbours(Point point)
            {
                return this.graph.GetNeighbours(point);
            }

            protected override float GetDistance(Point point1, Point point2)
            {
                return point1.GetDistanceTo(point2);
            }

            protected override float GetHeuristic(Point point1, Point point2)
            {
                //Manhattan distance:
                return point1.GetDistanceTo(point2);
            }
        }

#if UNITY_EDITOR
        [SerializeField]
        private bool drawGizmos;

        [SerializeField]
        private Color gizmosColor = Color.magenta;

        protected virtual void OnDrawGizmos()
        {
            if (this.drawGizmos)
            {
                this.DrawPointsGraph();
            }
        }

        private void DrawPointsGraph()
        {
            var previousColor = UnityEngine.Gizmos.color;
            Handles.color = this.gizmosColor;

            var points = this.GetAllPoints();
            foreach (var point in points)
            {
                var neighbours = this.GetNeighbours(point);
                DrawNeighbors(point, neighbours);
            }

            Handles.color = previousColor;
        }

        private static void DrawNeighbors(Point point, IEnumerable<Point> neighbours)
        {
            foreach (var neighbour in neighbours)
            {
                Handles.DrawLine(point.WorldPosition, neighbour.WorldPosition, 2);
            }
        }
#endif
    }
}