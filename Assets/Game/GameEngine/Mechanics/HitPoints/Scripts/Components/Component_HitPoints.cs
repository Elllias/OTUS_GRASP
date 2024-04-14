using System;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_HitPoints :
        IComponent_GetHitPoints,
        IComponent_SetHitPoints,
        IComponent_GetMaxHitPoints,
        IComponent_SetMaxHitPoints,
        IComponent_AddHitPoints,
        IComponent_OnHitPointsChanged,
        IComponent_OnMaxHitPointsChanged,
        IComponent_SetupHitPoints
    {
        public event Action<int> OnHitPointsChanged
        {
            add { this.engine.OnCurrentPointsChanged += value; }
            remove { this.engine.OnCurrentPointsChanged -= value; }
        }

        public event Action<int> OnMaxHitPointsChanged
        {
            add { this.engine.OnMaxPointsChanged += value; }
            remove { this.engine.OnMaxPointsChanged -= value; }
        }

        public int HitPoints
        {
            get { return this.engine.Current; }
        }

        public int MaxHitPoints
        {
            get { return this.engine.Max; }
        }

        private readonly IHitPoints engine;

        public Component_HitPoints(IHitPoints engine)
        {
            this.engine = engine;
        }

        public void Setup(int current, int max)
        {
            this.engine.Setup(current, max);
        }

        public void SetHitPoints(int hitPoints)
        {
            this.engine.Current = hitPoints;
        }

        public void SetMaxHitPoints(int hitPoints)
        {
            this.engine.Max = hitPoints;
        }

        public void AddHitPoints(int range)
        {
            this.engine.Current += range;
        }
    }
}