using System;
using Components;
using Leopotam.EcsLite.Entities;

namespace Requests
{
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
    public struct DestroyRequest
    {
        public int EntityId;
    }

    [Serializable]
    public struct ViewTriggerRequest
    {
        public Entity Source;
        public Entity Target;
    }

    [Serializable]
    public struct HealthChangeRequest
    {
        public Entity Target;
        public int Delta;
    }

    [Serializable]
    public struct EnemyDetectionRequest
    {
        public Entity Source;
        public Entity Target;
    }
}