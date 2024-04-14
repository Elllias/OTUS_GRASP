using System;

namespace Game.GameEngine.Mechanics
{
    public interface  IComponent_MeleeCombat
    {
        event Action<CombatOperation> OnCombatStarted;

        event Action<CombatOperation> OnCombatStopped;

        bool IsCombat { get; }

        bool CanStartCombat(CombatOperation operation);
        
        void StartCombat(CombatOperation operation);
        
        void StopCombat();
    }
}