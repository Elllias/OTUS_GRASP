using System;
using System.Collections.Generic;
using UnityEngine;

namespace Polygons
{
    [Serializable]
    public sealed class MonoPolygonGroup
    {
        [SerializeField]
        private List<MonoPolygon> polygons = new();

        public void AddPolygon(MonoPolygon zone)
        {
            this.polygons.Add(zone);
        }

        public void RemovePolygon(MonoPolygon zone)
        {
            this.polygons.Remove(zone);
        }

        public bool IsPointInside(Vector3 position)
        {
            for (int i = 0, count = this.polygons.Count; i < count; i++)
            {
                var polygon = this.polygons[i];
                if (polygon.IsPointInside(position))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ClampPosition(Vector3 position, out float distance, out Vector3 targetPoint)
        {
            var minDistance = Mathf.Infinity;
            targetPoint = Vector3.zero;

            var pointFound = false;

            for (int i = 0, count = this.polygons.Count; i < count; i++)
            {
                var polygon = this.polygons[i];
                if (!polygon.ClampPosition(position, out distance, out var clampedPosition))
                {
                    continue;
                }

                if (distance < minDistance)
                {
                    minDistance = distance;
                    targetPoint = clampedPosition;
                    pointFound = true;
                }
            }

            distance = minDistance;
            return pointFound;
        }

        public Vector3[] GetAllPoints()
        {
            var result = new List<Vector3>();
            for (int i = 0, count = this.polygons.Count; i < count; i++)
            {
                var polygon = this.polygons[i];
                result.AddRange(polygon.GetAllPoints());
            }

            return result.ToArray();
        }
    }
}