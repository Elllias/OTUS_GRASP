namespace Game.GameEngine.Mechanics
{
    public static class MechanicsUtils
    {
        public static DestroyArgs ConvertToDestroyEvent(TakeDamageArgs damageArgs)
        {
            var damageReason = damageArgs.reason;
            DestroyReason destroyReason;
            if (damageReason == TakeDamageReason.SELF)
            {
                destroyReason = DestroyReason.SELF;
            }
            else if (damageReason == TakeDamageReason.BULLET)
            {
                destroyReason = DestroyReason.BULLET;
            }
            else if (damageReason == TakeDamageReason.MELEE)
            {
                destroyReason = DestroyReason.ATTACKER;
            }
            else
            {
                destroyReason = DestroyReason.UNDEFINED;
            }

            return new DestroyArgs(destroyReason, damageArgs.source);
        }
    }
}