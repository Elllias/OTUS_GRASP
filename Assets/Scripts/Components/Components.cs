using System;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using Views;

namespace Components
{
    [Serializable]
    public struct PositionComponent
    {
        public Vector3 Value;
    }

    [Serializable]
    public struct MoveSpeedComponent
    {
        public float Value;
    }

    [Serializable]
    public struct MoveDirectionComponent
    {
        public Vector3 Value;
    }

    [Serializable]
    public struct TransformComponent
    {
        public Transform Value;
    }
    
    [Serializable]
    public struct FirePointComponent
    {
        public Transform Value;
    }

    [Serializable]
    public struct PrefabComponent
    {
        public Entity Value;
    }

    [Serializable]
    public struct HealthComponent
    {
        public int Value;
    }

    [Serializable]
    public struct SpawnCubeRequest
    {
        public MoveDirectionComponent MoveDirectionComponent;
        public PositionComponent PositionComponent;
        public PrefabComponent PrefabComponent;
    }
    
    [Serializable]
    public struct FireRequest
    {
        public TransformComponent Source;
        public TransformComponent Target;
        public PrefabComponent BulletPrefab;
    }

    [Serializable]
    public struct DamageComponent
    {
        public int Value;
    }

    [Serializable]
    public struct TeamComponent
    {
        public bool IsRedTeam;
    }

    [Serializable]
    public struct EnemyDetectionRequest
    {
        public Entity Source;
        public Entity Target;
    }

    [Serializable]
    public struct BulletViewComponent
    {
        public BulletView Value;
    }

    [Serializable]
    public struct UnitViewComponent
    {
        public UnitView Value;
    }

    [Serializable]
    public struct LifetimeComponent
    {
        public float Value;
    }

    [Serializable]
    public struct DestroyRequest
    {
        public int EntityId;
    }
}