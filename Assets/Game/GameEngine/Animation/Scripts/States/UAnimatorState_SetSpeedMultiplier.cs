using System;
using System.Runtime.Serialization;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Animation
{
    [AddComponentMenu("GameEngine/Animation/Animator State «Set Speed Multiplier»")]
    public sealed class UAnimatorState_SetSpeedMultiplier : MonoState, IAnimatorMultiplier
    {
        [SerializeField]
        private UAnimatorMachine system;

        [Space]
        [LabelText("Multiplier Source")]
        [SerializeField]
        private Mode mode;

        [ShowIf("mode", Mode.MONO_BEHAVIOUR)]
        [OptionalField]
        [SerializeField]
        private MonoFloatVariable monoFloat;

        [ShowIf("mode", Mode.SCRIPTABLE_OBJECT)]
        [OptionalField]
        [SerializeField]
        private ScriptableFloat scriptableFloat;

        [ShowIf("mode", Mode.CUSTOM)]
        [SerializeField]
        private float customFloat;

        public override void Enter()
        {
            this.system.AddSpeedMultiplier(this);
        }

        public override void Exit()
        {
            this.system.RemoveSpeedMultiplier(this);
        }

        float IAnimatorMultiplier.GetValue()
        {
            if (this.mode == Mode.MONO_BEHAVIOUR)
            {
                return this.monoFloat.Current;
            }

            if (this.mode == Mode.SCRIPTABLE_OBJECT)
            {
                return this.scriptableFloat.Current;
            }

            if (this.mode == Mode.CUSTOM)
            {
                return this.customFloat;
            }

            throw new Exception($"Mode {this.mode} is undefined!");
        }

        private enum Mode
        {
            MONO_BEHAVIOUR = 0,
            SCRIPTABLE_OBJECT = 1,
            CUSTOM = 2
        }
    }
}