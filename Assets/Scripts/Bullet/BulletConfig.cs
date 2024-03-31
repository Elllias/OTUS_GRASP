using Enum;
using UnityEngine;

namespace Bullet
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Bullets/New BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        public EPhysicsLayer PhysicsLayer;
        public Color Color;
        public int Damage;
        public float Speed;
    }
}