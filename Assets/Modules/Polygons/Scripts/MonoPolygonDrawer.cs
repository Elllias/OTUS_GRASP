#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace Polygons
{
    [Serializable]
    public sealed class MonoPolygonDrawer
    {
        [SerializeField]
        private Color strokeColor;

        [SerializeField]
        private float strokeThickness = 5.0f;

        [SerializeField]
        private Color fillColor;

        public void DrawPolygon(Polygon polygon)
        {
            if (polygon == null || polygon.Length < 3)
            {
                return;
            }

            var length = polygon.Length;
            var posiitons = new Vector3[length];
            for (var i = 0; i < length; i++)
            {
                var point = polygon.GetPoint(i);
                posiitons[i] = this.ConvertToWorldPosition(point);
            }
            
            var color = Handles.color;
            Handles.color = this.strokeColor;
            Handles.DrawAAPolyLine(this.strokeThickness, posiitons);
            Handles.DrawAAPolyLine(this.strokeThickness, posiitons[0], posiitons[^1]);

            Handles.color = this.fillColor;
            Handles.DrawAAConvexPolygon(posiitons);

            Handles.color = color;
        }
    
        private Vector3 ConvertToWorldPosition(Vector2 point)
        {
            return new Vector3(point.x, 0.0f, point.y);
        }
    }
}
#endif