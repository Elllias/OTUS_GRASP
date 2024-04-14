using System;
using Declarative;
using Entities;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Lessons.Character.Engines;
using Lessons.Gameplay.Interaction;
using Lessons.StateMachines;
using Lessons.StateMachines.States;
using Lessons.Utils;
using UnityEngine;
using TransformSynchronizer = Lessons.Utils.TransformSynchronizer;

namespace Lessons.Character.Model
{
    [Serializable]
    public sealed class CharacterCore
    {
        [Section]
        public CharacterLife life;

        [Section]
        public CharacterMovement movement;

        [Section]
        public CharacterGathering gathering;

        [Section]
        public CharacterCollision collision;

        [Section]
        public CharacterStates states;
    }

    [Serializable]
    public sealed class CharacterLife
    {
        public AtomicVariable<bool> isAlive;
    }

    [Serializable]
    public sealed class CharacterMovement
    {
        public Transform transform;

        public AtomicVariable<float> movementSpeed = new(6f);
        public AtomicVariable<float> rotationSpeed = new(10f);
        public MovementDirectionVariable movementDirection;

        public MoveInDirectionEngine moveInDirectionEngine;
        public RotateInDirectionEngine rotateInDirectionEngine;

        [Construct]
        public void Construct()
        {
            moveInDirectionEngine.Construct(transform, movementSpeed);
            rotateInDirectionEngine.Construct(transform, rotationSpeed);
        }
    }

    [Serializable]
    public sealed class CharacterGathering
    {
        public AtomicVariable<float> duration = new(3);
        public AtomicVariable<float> minDistance = new(1.25f);

        public AtomicProcess<GatherResourceCommand> process;

        [Construct]
        public void Construct(CharacterMovement movement)
        {
            this.process.Condition = cmd =>
            {
                var myPosition = movement.transform.position;
                var resourcePosition = cmd.Position;
                return Vector3.Distance(myPosition, resourcePosition) <= this.minDistance.Value;
            };
                
            this.process.OnStarted += cmd =>
            {
                var myPosition = movement.transform.position;
                var resourcePosition = cmd.Position;
                var direction = (resourcePosition - myPosition).normalized;
                movement.transform.rotation = Quaternion.LookRotation(direction);
            };
        }
    }

    [Serializable]
    public sealed class CharacterCollision
    {
        public CollisionSensor sensor;
        public TransformSynchronizer synchronizer;
    }

    [Serializable]
    public sealed class CharacterStates
    {
        public StateMachine<CharacterStateType> stateMachine;

        [Section]
        public IdleState idleState;

        [Section]
        public RunState runState;

        [Section]
        public DeadState deadState;

        [Section]
        public GatherCompositeState gatherState;

        [Construct]
        public void Construct(CharacterModel root)
        {
            root.onStart += () => this.stateMachine.Enter();
        
            stateMachine.Construct(
                (CharacterStateType.Idle, idleState),
                (CharacterStateType.Run, runState),
                (CharacterStateType.Dead, deadState),
                (CharacterStateType.Gathering, gatherState)
            );
        }

        [Construct]
        public void ConstructTransitions(CharacterLife life, CharacterMovement movement, CharacterGathering gathering)
        {
            life.isAlive.ValueChanged += isAlive =>
            {
                var stateType = isAlive ? CharacterStateType.Idle : CharacterStateType.Dead;
                stateMachine.SwitchState(stateType);
            };

            movement.movementDirection.MovementStarted += () =>
            {
                if (life.isAlive)
                {
                    stateMachine.SwitchState(CharacterStateType.Run);
                }
            };

            movement.movementDirection.MovementFinished += () =>
            {
                if (life.isAlive && stateMachine.CurrentState == CharacterStateType.Run)
                {
                    stateMachine.SwitchState(CharacterStateType.Idle);
                }
            };

            gathering.process.OnStarted += _ =>
            {
                if (life.isAlive)
                {
                    stateMachine.SwitchState(CharacterStateType.Gathering);
                }
            };
            
            gathering.process.OnStopped += success =>
            {
                if (life.isAlive)
                {
                    stateMachine.SwitchState(CharacterStateType.Idle);
                }
            };
        }
    }
}