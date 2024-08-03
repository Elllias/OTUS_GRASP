using Leopotam.EcsLite.Di;

namespace Leopotam.EcsLite.Events
{
    public struct EcsListenerInject<T> : IEcsDataInject where T : struct
    {
        public EcsListener<T> Value;
        
        private string worldName;

        void IEcsDataInject.Fill(IEcsSystems systems)
        {
            Value = new EcsListener<T>(systems.GetWorld(this.worldName));
        }
        
        public static implicit operator EcsListenerInject<T>(string worldName)
        {
            return new EcsListenerInject<T> {worldName = worldName};
        }
    }

    public struct EcsListenerInject<T1, T2> : IEcsDataInject
        where T1 : struct
        where T2 : struct
    {
        public EcsListener<T1, T2> Value;
        
        private string worldName;

        void IEcsDataInject.Fill(IEcsSystems systems)
        {
            Value = new EcsListener<T1, T2>(systems.GetWorld(this.worldName));
        }
        
        public static implicit operator EcsListenerInject<T1, T2>(string worldName)
        {
            return new EcsListenerInject<T1, T2> {worldName = worldName};
        }
    }

    public struct EcsListenerInject<T1, T2, T3> : IEcsDataInject
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        public EcsListener<T1, T2, T3> Value;

        private string worldName;

        void IEcsDataInject.Fill(IEcsSystems systems)
        {
            Value = new EcsListener<T1, T2, T3>(systems.GetWorld(this.worldName));
        }
        
        public static implicit operator EcsListenerInject<T1, T2, T3>(string worldName)
        {
            return new EcsListenerInject<T1, T2, T3> {worldName = worldName};
        }
    }

    public struct EcsListenerInject<T1, T2, T3, T4> : IEcsDataInject
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        public EcsListener<T1, T2, T3, T4> Value;
        
        private string worldName;

        void IEcsDataInject.Fill(IEcsSystems systems)
        {
            Value = new EcsListener<T1, T2, T3, T4>(systems.GetWorld(this.worldName));
        }
        
        public static implicit operator EcsListenerInject<T1, T2, T3, T4>(string worldName)
        {
            return new EcsListenerInject<T1, T2, T3, T4> {worldName = worldName};
        }
    }
}