namespace Leopotam.EcsLite.Events
{
    public readonly struct EcsEmitter<T> where T : struct
    {
        private readonly EcsWorld world;
        private readonly EcsPool<T> pool;

        private readonly EcsPool<EcsEventMarker> eventPool;
        private readonly EcsPool<EcsRequestMarker> enqueuePool;

        public EcsEmitter(EcsWorld world)
        {
            this.world = world;
            this.pool = this.world.GetPool<T>();

            this.eventPool = this.world.GetPool<EcsEventMarker>();
            this.enqueuePool = this.world.GetPool<EcsRequestMarker>();
        }

        public void InvokeEvent(T arg)
        {
            int entity = this.world.NewEntity();
            this.pool.Add(entity) = arg;
            this.eventPool.Add(entity) = new EcsEventMarker();
        }

        public void EnqueueEvent(T arg)
        {
            int evnt = this.world.NewEntity();
            this.pool.Add(evnt) = arg;
            this.enqueuePool.Add(evnt) = new EcsRequestMarker();
        }
    }

    public readonly struct EcsEmitter<T1, T2> where T1 : struct where T2 : struct
    {
        private readonly EcsWorld world;
        private readonly EcsPool<T1> pool1;
        private readonly EcsPool<T2> pool2;

        private readonly EcsPool<EcsEventMarker> eventPool;
        private readonly EcsPool<EcsRequestMarker> requestPool;

        public EcsEmitter(EcsWorld world)
        {
            this.world = world;
            this.pool1 = this.world.GetPool<T1>();
            this.pool2 = this.world.GetPool<T2>();

            this.eventPool = this.world.GetPool<EcsEventMarker>();
            this.requestPool = this.world.GetPool<EcsRequestMarker>();
        }

        public void InvokeEvent(T1 arg1, T2 arg2)
        {
            int entity = this.world.NewEntity();
            this.pool1.Add(entity) = arg1;
            this.pool2.Add(entity) = arg2;
            this.eventPool.Add(entity) = new EcsEventMarker();
        }

        public void EnqueueEvent(T1 arg1, T2 arg2)
        {
            int entity = this.world.NewEntity();
            this.pool1.Add(entity) = arg1;
            this.pool2.Add(entity) = arg2;
            this.requestPool.Add(entity) = new EcsRequestMarker();
        }
    }


    public readonly struct EcsEmitter<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        private readonly EcsWorld world;

        private readonly EcsPool<T1> pool1;
        private readonly EcsPool<T2> pool2;
        private readonly EcsPool<T3> pool3;

        private readonly EcsPool<EcsEventMarker> eventPool;
        private readonly EcsPool<EcsRequestMarker> requestPool;

        public EcsEmitter(EcsWorld world)
        {
            this.world = world;
            this.pool1 = this.world.GetPool<T1>();
            this.pool2 = this.world.GetPool<T2>();
            this.pool3 = world.GetPool<T3>();

            this.eventPool = this.world.GetPool<EcsEventMarker>();
            this.requestPool = this.world.GetPool<EcsRequestMarker>();
        }

        public void InvokeEvent(T1 arg1, T2 arg2, T3 arg3)
        {
            int entity = this.world.NewEntity();
            this.pool1.Add(entity) = arg1;
            this.pool2.Add(entity) = arg2;
            this.pool3.Add(entity) = arg3;
            this.eventPool.Add(entity) = new EcsEventMarker();
        }

        public void EnqueueEvent(T1 arg1, T2 arg2, T3 arg3)
        {
            int entity = this.world.NewEntity();
            this.pool1.Add(entity) = arg1;
            this.pool2.Add(entity) = arg2;
            this.pool3.Add(entity) = arg3;
            this.requestPool.Add(entity) = new EcsRequestMarker();
        }
    }

    public readonly struct EcsEmitter<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        private readonly EcsWorld world;

        private readonly EcsPool<T1> pool1;
        private readonly EcsPool<T2> pool2;
        private readonly EcsPool<T3> pool3;
        private readonly EcsPool<T4> pool4;

        private readonly EcsPool<EcsEventMarker> eventPool;
        private readonly EcsPool<EcsRequestMarker> requestPool;

        public EcsEmitter(EcsWorld world)
        {
            this.world = world;
            this.pool1 = this.world.GetPool<T1>();
            this.pool2 = this.world.GetPool<T2>();
            this.pool3 = this.world.GetPool<T3>();
            this.pool4 = world.GetPool<T4>();

            this.eventPool = this.world.GetPool<EcsEventMarker>();
            this.requestPool = this.world.GetPool<EcsRequestMarker>();
        }

        public void InvokeEvent(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            int entity = this.world.NewEntity();
            this.pool1.Add(entity) = arg1;
            this.pool2.Add(entity) = arg2;
            this.pool3.Add(entity) = arg3;
            this.pool4.Add(entity) = arg4;

            this.eventPool.Add(entity) = new EcsEventMarker();
        }

        public void EnqueueEvent(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            int entity = this.world.NewEntity();
            this.pool1.Add(entity) = arg1;
            this.pool2.Add(entity) = arg2;
            this.pool3.Add(entity) = arg3;
            this.pool4.Add(entity) = arg4;

            this.requestPool.Add(entity) = new EcsRequestMarker();
        }
    }
}