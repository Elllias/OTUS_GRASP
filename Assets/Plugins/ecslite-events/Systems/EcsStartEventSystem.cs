namespace Leopotam.EcsLite.Events
{
    //Add this system first:
    public sealed class EcsStartEventSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly string worldName;
        
        private EcsFilter filter;
        private EcsPool<EcsRequestMarker> requestPool;
        private EcsPool<EcsEventMarker> eventPool;

        public EcsStartEventSystem(string worldName = null)
        {
            this.worldName = worldName;
        }

        void IEcsInitSystem.Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld(this.worldName);
            
            this.filter = world.Filter<EcsRequestMarker>().End();
            this.requestPool = world.GetPool<EcsRequestMarker>();
            this.eventPool = world.GetPool<EcsEventMarker>();
        }

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (int entitiy in this.filter)
            {
                this.requestPool.Del(entitiy);
                this.eventPool.Add(entitiy) = new EcsEventMarker();
            }
        }
    }
}