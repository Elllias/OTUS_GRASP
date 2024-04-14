namespace Game.GameEngine.Mechanics
{
    public sealed class Component_IsAlive_HitPoints : IComponent_IsAlive
    {
        public bool IsAlive
        {
            get { return this.engine.Current > 0; }
        }

        private readonly IHitPoints engine;

        public Component_IsAlive_HitPoints(IHitPoints engine)
        {
            this.engine = engine;
        }
    }
}