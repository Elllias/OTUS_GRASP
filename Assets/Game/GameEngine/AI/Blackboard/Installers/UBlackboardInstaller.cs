using System;
using AI.Blackboards;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.AI
{
    [AddComponentMenu("GameEngine/AI/Blackboard/Blackboard Installer")]
    public sealed class UBlackboardInstaller : UBlackboardInstallerBase
    {
        [SerializeField]
        private RefrenceVariable[] referenceVariables;
        
        [SerializeField]
        private UnityVariable[] unityVariables;

        protected override void Install(IBlackboard blackboard, GameContext context)
        {
            for (int i = 0, count = this.referenceVariables.Length; i < count; i++)
            {
                var variable = this.referenceVariables[i];
                blackboard.AddVariable(variable.key, variable.value);
            }
            
            for (int i = 0, count = this.unityVariables.Length; i < count; i++)
            {
                var variable = this.unityVariables[i];
                blackboard.AddVariable(variable.key, variable.value);
            }
        }

        [Serializable]
        private sealed class RefrenceVariable
        {
            [BlackboardKey]
            [SerializeField]
            public string key;

            [SerializeReference]
            public object value;
        }
        
        [Serializable]
        private sealed class UnityVariable
        {
            [BlackboardKey]
            [SerializeField]
            public string key;

            [SerializeField]
            public UnityEngine.Object value;
        }
    }
}