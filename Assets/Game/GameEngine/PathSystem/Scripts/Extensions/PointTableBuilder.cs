using System.Collections.Generic;

namespace Game.GameEngine.PathSystem
{
    public static class PointTableBuilder
    {
        public static Dictionary<Point, IEnumerable<Point>> CreateTable(Point[] points, float neighbourDistance)
        {
            var result = new Dictionary<Point, IEnumerable<Point>>();
            for (int i = 0, count = points.Length; i < count; i++)
            {
                var node = points[i];
                AddNeighbourDistanceNode(node, points, neighbourDistance, result);
            }

            return result;
        }

        private static void AddNeighbourDistanceNode(
            Point node,
            Point[] allPoints,
            float neighbourDistance,
            Dictionary<Point, IEnumerable<Point>> neighbourTable
        )
        {
            var neighbours = new List<Point>();

            for (int i = 0, count = allPoints.Length; i < count; i++)
            {
                var point = allPoints[i];
                if (ReferenceEquals(node, point))
                {
                    continue;
                }

                var distance = node.GetDistanceTo(point);
                if (distance <= neighbourDistance)
                {
                    neighbours.Add(point);
                }
            }

            neighbourTable[node] = neighbours;
        }

        public static Dictionary<Point, IEnumerable<Point>> CreateTable(PointsConnection[] connections)
        {
            var result = new Dictionary<Point, IEnumerable<Point>>();
            for (int i = 0, count = connections.Length; i < count; i++)
            {
                var connection = connections[i];
                AddConnectionNode(connection, result);
            }

            return result;
        }

        private static void AddConnectionNode(
            PointsConnection connection,
            Dictionary<Point, IEnumerable<Point>> neighbourTable
        )
        {
            var connectedPoints = connection.connectedPoints;
            var count = connectedPoints.Length;
            
            for (var i = 0; i < count; i++)
            {
                var point = connectedPoints[i];
                if (point == null)
                {
                    continue;
                }
                
                if (!neighbourTable.TryGetValue(point, out var neighbours))
                {
                    neighbours = new HashSet<Point>();
                    neighbourTable[point] = neighbours;
                }

                var neighboursSet = (HashSet<Point>) neighbours; 
                for (var j = 0; j < count; j++)
                {
                    var otherPoint = connectedPoints[j];
                    if (otherPoint == null)
                    {
                        continue;
                    }
                    
                    if (!ReferenceEquals(point, otherPoint))
                    {
                        neighboursSet.Add(otherPoint);
                    }
                }
            }
        }
    }
}