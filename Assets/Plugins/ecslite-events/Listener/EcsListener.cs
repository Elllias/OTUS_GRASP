namespace Leopotam.EcsLite.Events
{
    public readonly struct EcsListener<T> where T : struct
    {
        private readonly EcsFilter filter;
        private readonly EcsPool<T> pool;

        public EcsListener(EcsWorld world)
        {
            this.filter = world.Filter<T>().Inc<EcsEventMarker>().End();
            this.pool = world.GetPool<T>();
        }

        public ref T Get(int entity)
        {
            return ref this.pool.Get(entity);
        }

        public EcsFilter.Enumerator GetEnumerator()
        {
            return this.filter.GetEnumerator();
        }
    }

    public readonly struct EcsListener<T1, T2>
        where T1 : struct
        where T2 : struct
    {
        private readonly EcsFilter filter;
        private readonly EcsPool<T1> pool1;
        private readonly EcsPool<T2> pool2;

        public EcsListener(EcsWorld world)
        {
            this.filter = world.Filter<T1>().Inc<T2>().Inc<EcsEventMarker>().End();
            this.pool1 = world.GetPool<T1>();
            this.pool2 = world.GetPool<T2>();
        }

        public ref T1 Get1(int entity)
        {
            return ref this.pool1.Get(entity);
        }

        public ref T2 Get2(int entity)
        {
            return ref this.pool2.Get(entity);
        }

        public EcsFilter.Enumerator GetEnumerator()
        {
            return this.filter.GetEnumerator();
        }
    }

    public readonly struct EcsListener<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        private readonly EcsFilter filter;

        private readonly EcsPool<T1> pool1;
        private readonly EcsPool<T2> pool2;
        private readonly EcsPool<T3> pool3;

        public EcsListener(EcsWorld world)
        {
            this.filter = world.Filter<T1>().Inc<T2>().Inc<EcsEventMarker>().End();

            this.pool1 = world.GetPool<T1>();
            this.pool2 = world.GetPool<T2>();
            this.pool3 = world.GetPool<T3>();
        }

        public ref T1 Get1(int entity)
        {
            return ref this.pool1.Get(entity);
        }

        public ref T2 Get2(int entity)
        {
            return ref this.pool2.Get(entity);
        }

        public ref T3 Get3(int entity)
        {
            return ref this.pool3.Get(entity);
        }

        public EcsFilter.Enumerator GetEnumerator()
        {
            return this.filter.GetEnumerator();
        }
    }

    public readonly struct EcsListener<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        private readonly EcsFilter filter;

        private readonly EcsPool<T1> pool1;
        private readonly EcsPool<T2> pool2;
        private readonly EcsPool<T3> pool3;
        private readonly EcsPool<T4> pool4;

        public EcsListener(EcsWorld world)
        {
            this.filter = world.Filter<T1>().Inc<T2>().Inc<EcsEventMarker>().End();

            this.pool1 = world.GetPool<T1>();
            this.pool2 = world.GetPool<T2>();
            this.pool3 = world.GetPool<T3>();
            this.pool4 = world.GetPool<T4>();
        }

        public ref T1 Get1(int entity)
        {
            return ref this.pool1.Get(entity);
        }

        public ref T2 Get2(int entity)
        {
            return ref this.pool2.Get(entity);
        }

        public ref T3 Get3(int entity)
        {
            return ref this.pool3.Get(entity);
        }

        public ref T4 Get4(int entity)
        {
            return ref this.pool4.Get(entity);
        }

        public EcsFilter.Enumerator GetEnumerator()
        {
            return this.filter.GetEnumerator();
        }
    }
}