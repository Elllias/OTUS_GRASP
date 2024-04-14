using Game.GameEngine;
using Polygons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public sealed class HeroWalkableSurface : IWalkableSurface
    {
        [ReadOnly]
        [ShowInInspector]
        private readonly MonoPolygonGroup group = new();

        public void RegisterPolygon(MonoPolygon polygon)
        {
            this.group.AddPolygon(polygon);
        }

        public void UnregisterPolygon(MonoPolygon polygon)
        {
            this.group.RemovePolygon(polygon);
        }
    
        public bool IsAvailablePosition(Vector3 position)
        {
            return this.group.IsPointInside(position);
        }

        public bool FindAvailablePosition(Vector3 position, out Vector3 clampedPosition)
        {
            return this.group.ClampPosition(position, out _, out clampedPosition);
        }
    }
}