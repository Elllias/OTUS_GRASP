namespace Game.GameEngine.Mechanics
{
    public static class HitPointsExtensions
    {
        public static void RestoreToFull(this IHitPoints it)
        {
            it.Current = it.Max;
        }

        public static bool IsExists(this IHitPoints it)
        {
            return it.Current > 0;
        }

        public static bool IsOver(this IHitPoints it)
        {
            return it.Current <= 0;            
        }
    }
}