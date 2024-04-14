using System;
using AI.Blackboards;
using Entities;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.AI
{
    [AddComponentMenu("GameEngine/AI/Blackboard/Blackboard Installer «Entities»")]
    public sealed class UBlackboardInstaller_Entities : UBlackboardInstallerBase
    {
        [SerializeField]
        private Variable[] variables;

        protected override void Install(IBlackboard blackboard, GameContext context)
        {
            for (int i = 0, count = this.variables.Length; i < count; i++)
            {
                var variable = this.variables[i];
                blackboard.AddVariable(variable.key, variable.value);
            }
        }

        [Serializable]
        private sealed class Variable
        {
            [BlackboardKey]
            [SerializeField]
            public string key;

            [SerializeField]
            public MonoEntity value;
        }
    }
}