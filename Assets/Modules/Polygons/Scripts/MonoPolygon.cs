using UnityEngine;

namespace Polygons
{
    public sealed class MonoPolygon : MonoBehaviour
    {
        private Polygon polygon;

        private void Awake()
        {
            this.Init();
        }

        public bool IsPointInside(Vector3 position)
        {
            var point2D = this.ConvertToPoint(position);
            return this.polygon.IsPointInside(point2D);
        }

        public bool ClampPosition(Vector3 position, out float distance, out Vector3 clampedPosition)
        {
            var point2D = this.ConvertToPoint(position);
            if (this.polygon.ClampPosition(point2D, out distance, out var clampedPoint2D))
            {
                clampedPosition = this.ConventToPosition(clampedPoint2D);
                return true;
            }

            clampedPosition = Vector3.zero;
            return false;
        }

        public Vector3[] GetAllPoints()
        {
            var count = this.polygon.Length;
            var result = new Vector3[count];
            for (var i = 0; i < count; i++)
            {
                var point2D = this.polygon.GetPoint(i);
                result[i] = new Vector3(point2D.x, 0.0f, point2D.y);
            }
            
            return result;
        }

        private void Init()
        {
            var count = this.transform.childCount;
            var points = new Vector2[count];

            for (var i = 0; i < count; i++)
            {
                var child = this.transform.GetChild(i);
                var worldPosition = child.position;
                points[i] = this.ConvertToPoint(worldPosition);
            }

            this.polygon = new Polygon(points);
        }

        private Vector2 ConvertToPoint(Vector3 position)
        {
            return new Vector2(position.x, position.z);
        }

        private Vector3 ConventToPosition(Vector2 point)
        {
            return new Vector3(point.x, 0.0f, point.y);
        }

#if UNITY_EDITOR
        [Space, SerializeField]
        private bool drawGizmos;

        [SerializeField]
        private MonoPolygonDrawer drawer = new();

        private void OnDrawGizmos()
        {
            if (this.gameObject.activeInHierarchy && this.drawGizmos)
            {
                this.Init();
                this.drawer.DrawPolygon(this.polygon);
            }
        }

        private void OnValidate()
        {
            this.Init();
        }
#endif
    }
}