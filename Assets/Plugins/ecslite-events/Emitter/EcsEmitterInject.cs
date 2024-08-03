using Leopotam.EcsLite.Di;

namespace Leopotam.EcsLite.Events
{
    public struct EcsEmitterInject<T> : IEcsDataInject where T : struct
    {
        public EcsEmitter<T> Value;

        private string worldName;

        void IEcsDataInject.Fill(IEcsSystems systems)
        {
            Value = new EcsEmitter<T>(systems.GetWorld(this.worldName));
        }

        public static implicit operator EcsEmitterInject<T>(string worldName)
        {
            return new EcsEmitterInject<T> {worldName = worldName};
        }
    }

    public struct EcsEmitterInject<T1, T2> : IEcsDataInject
        where T1 : struct
        where T2 : struct
    {
        public EcsEmitter<T1, T2> Value;

        private string worldName;

        void IEcsDataInject.Fill(IEcsSystems systems)
        {
            Value = new EcsEmitter<T1, T2>(systems.GetWorld(this.worldName));
        }

        public static implicit operator EcsEmitterInject<T1, T2>(string worldName)
        {
            return new EcsEmitterInject<T1, T2> {worldName = worldName};
        }
    }

    public struct EcsEmitterInject<T1, T2, T3> : IEcsDataInject
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        public EcsEmitter<T1, T2, T3> Value;

        private string worldName;

        void IEcsDataInject.Fill(IEcsSystems systems)
        {
            Value = new EcsEmitter<T1, T2, T3>(systems.GetWorld(this.worldName));
        }

        public static implicit operator EcsEmitterInject<T1, T2, T3>(string worldName)
        {
            return new EcsEmitterInject<T1, T2, T3> {worldName = worldName};
        }
    }

    public struct EcsEmitterInject<T1, T2, T3, T4> : IEcsDataInject
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        public EcsEmitter<T1, T2, T3, T4> Value;

        private string worldName;

        void IEcsDataInject.Fill(IEcsSystems systems)
        {
            Value = new EcsEmitter<T1, T2, T3, T4>(systems.GetWorld(this.worldName));
        }

        public static implicit operator EcsEmitterInject<T1, T2, T3, T4>(string worldName)
        {
            return new EcsEmitterInject<T1, T2, T3, T4> {worldName = worldName};
        }
    }
}