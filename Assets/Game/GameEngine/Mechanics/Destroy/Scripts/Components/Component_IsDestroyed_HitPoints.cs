namespace Game.GameEngine.Mechanics
{
    public sealed class Component_IsDestroyed_HitPoints : IComponent_IsDestroyed
    {
        public bool IsDestroyed
        {
            get { return this.hitPointsEngine.Current <= 0; }
        }

        private readonly IHitPoints hitPointsEngine;

        public Component_IsDestroyed_HitPoints(IHitPoints hitPointsEngine)
        {
            this.hitPointsEngine = hitPointsEngine;
        }
    }
}