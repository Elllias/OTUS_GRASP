using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Component «Melee Combat»")]
    public sealed class UComponent_MeleeCombat : MonoBehaviour, IComponent_MeleeCombat
    {
        public event Action<CombatOperation> OnCombatStarted
        {
            add { this.combatOperator.OnStarted += value; }
            remove { this.combatOperator.OnStarted -= value; }
        }

        public event Action<CombatOperation> OnCombatStopped
        {
            add { this.combatOperator.OnStopped += value; }
            remove { this.combatOperator.OnStopped -= value; }
        }

        public bool IsCombat
        {
            get { return this.combatOperator.IsActive; }
        }

        [SerializeField]
        private UCombatOperator combatOperator;

        public bool CanStartCombat(CombatOperation operation)
        {
            return this.combatOperator.CanStart(operation);
        }

        public void StartCombat(CombatOperation operation)
        {
            this.combatOperator.DoStart(operation);
        }

        public void StopCombat()
        {
            this.combatOperator.Stop();
        }
    }
}