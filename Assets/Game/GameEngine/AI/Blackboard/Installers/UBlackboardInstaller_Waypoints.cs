using System.Collections.Generic;
using AI.Blackboards;
using AI.Iterators;
using AI.Waypoints;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.AI
{
    [AddComponentMenu("GameEngine/AI/Blackboard/Blackboard Installer «Waypoints»")]
    public sealed class UBlackboardInstaller_Waypoints : UBlackboardInstallerBase
    {
        [SerializeField]
        private WaypointsPath pointsPath;

        [SerializeField]
        private IteratorMode mode;
        
        [BlackboardKey]
        [SerializeField]
        private string iteratorKey;

        protected override void Install(IBlackboard blackboard, GameContext context)
        {
            var iterator = this.CreateIterator();
            blackboard.AddVariable(this.iteratorKey, iterator);
        }

        private IEnumerator<Vector3> CreateIterator()
        {
            var waypoints = this.pointsPath
                .GetPositionPoints()
                .ToArray();

            return IteratorFactory.CreateIterator(this.mode, waypoints);
        }
    }
}