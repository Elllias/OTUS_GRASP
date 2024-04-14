using System;
using Declarative;
using Elementary;
using Game.Gameplay.Hero;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Declarative
{
    public sealed class CharacterModel : DeclarativeModel //MonoBehaviour
    {
        [SerializeField, Section]
        public Core core = new();

        [SerializeField, Section]
        public View view = new();

        [Serializable]
        public sealed class Core
        {
            [SerializeField, Section]
            public Life life = new();

            [SerializeField, Section]
            public Move move = new();

            [SerializeField, Section]
            public Attack attack = new();

            [Serializable]
            public sealed class Life
            {
                [SerializeField]
                public IntVariable hitPoints = new();

                [ShowInInspector]
                public Emitter<int> onTakeDamage = new();

                [ShowInInspector]
                public Emitter onDeath = new();

                [Construct]
                public void Construct()
                {
                    this.onTakeDamage.AddListener(damage =>
                    {
                        this.hitPoints.Current -= damage;
                    });
                    this.hitPoints.AddListener(value =>
                    {
                        if (value <= 0) this.onDeath.Call();
                    });
                    this.onDeath.AddListener(() =>
                    {
                        Debug.Log("Character is died!");
                    });
                }
            }

            [Serializable]
            public sealed class Move
            {
                [SerializeField]
                public Transform transform;

                [ShowInInspector]
                public Emitter<Vector3> onMove = new();

                [Construct]
                public void Construct()
                {
                    this.onMove.AddListener(vector =>
                    {
                        this.transform.position += vector;
                    });
                }
            }

            [Serializable]
            public sealed class Attack
            {
                [SerializeField]
                public IntVariable damage = new();

                [ShowInInspector]
                public Emitter<GameObject> onAttack = new();

                [Construct]
                public void Construct()
                {
                    this.onAttack.AddListener(target =>
                    {
                        Debug.Log($"Deal damage {this.damage.Current} to {target.name}");
                    });
                }
            }
        }

        [Serializable]
        public sealed class View
        {
            [SerializeField]
            public Animator animator;

            [SerializeField]
            public ParticleSystem deathVFX;

            [SerializeField]
            public AudioSource audioSource;

            [SerializeField]
            public AudioClip attackSFX;

            [Construct]
            public void Construct(Core.Attack attack, Core.Life life)
            {
                attack.onAttack.AddListener(_ =>
                {
                    this.animator.Play("Attack", -1, 0);
                    this.audioSource.PlayOneShot(this.attackSFX);
                });

                life.onDeath.AddListener(() =>
                {
                    this.animator.Play("Death", -1, 0);
                    this.deathVFX.Play(withChildren: true);
                });
            }
        }
    }
}