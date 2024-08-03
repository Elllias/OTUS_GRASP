namespace Leopotam.EcsLite.Events
{
    //Add this system last:
    public sealed class EcsDeleteEventSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly string worldName;
        
        private EcsFilter filter;
        private EcsWorld world;

        public EcsDeleteEventSystem(string worldName = null)
        {
            this.worldName = worldName;
        }

        void IEcsInitSystem.Init(IEcsSystems systems)
        {
            this.world = systems.GetWorld(this.worldName);
            this.filter = this.world.Filter<EcsEventMarker>().End();
        }

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (int entity in this.filter)
            {
                this.world.DelEntity(entity);
            }
        }
    }
}