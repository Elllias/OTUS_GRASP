using System;
using Elementary;
using Game.GameEngine.Mechanics;
using Game.Meta;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class DialogueVisitor : TriggerVisitor<DialogueTrigger>
    {
        private IDialogueShower dialogueShower;

        [GameInject]
        public void Construct(IDialogueShower dialogueShower)
        {
            this.dialogueShower = dialogueShower;
        }
        
        [Space]
        [SerializeField]
        private float visitDelay = 0.2f;

        protected override bool CanEnter(DialogueTrigger target)
        {
            return true;
        }

        protected override ICondition ProvideConditions(DialogueTrigger target)
        {
            return new ConditionComposite(
                new ConditionCountdown(this.monoContext, seconds: this.visitDelay, startInstantly: true),
                new Condition_Entity_IsNotMoving(this.HeroService.GetHero())
            );
        }

        protected override void OnHeroVisit(DialogueTrigger trigger)
        {
            this.dialogueShower.ShowDialog(trigger.Dialogue);
        }

        protected override void OnHeroQuit(DialogueTrigger target)
        {
        }
    }
}