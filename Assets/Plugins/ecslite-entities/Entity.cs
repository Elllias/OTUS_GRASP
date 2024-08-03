using UnityEngine;

// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

namespace Leopotam.EcsLite.Entities
{
    public class Entity : MonoBehaviour
    {
        public int Id => this.id;

        private EcsWorld world;
        private int id = -1;

        [SerializeField]
        private EntityInstaller[] installers;

        public bool IsAlive()
        {
            return this.id != -1 && this.world != null;
        }

        public void Initialize(EcsWorld world)
        {
            int entity = world.NewEntity();
            this.Initialize(entity, world);
        }

        public void Initialize(int id, EcsWorld world)
        {
            this.id = id;
            this.world = world;

            for (int i = 0, count = this.installers.Length; i < count; i++)
            {
                EntityInstaller installer = this.installers[i];
                installer.Install(this);
            }
        }

        public void Dispose()
        {
            for (int i = 0, count = this.installers.Length; i < count; i++)
            {
                EntityInstaller installer = this.installers[i];
                installer.Dispose(this);
            }
            
            this.world.DelEntity(this.id);
            this.world = null;
            this.id = -1;
        }

        public void AddData<T>(T component) where T : struct
        {
            var pool = this.world.GetPool<T>();
            pool.Add(this.id) = component;
        }

        public void RemoveData<T>() where T : struct
        {
            var pool = this.world.GetPool<T>();
            pool.Del(this.id);
        }

        public ref T GetData<T>() where T : struct
        {
            EcsPool<T> pool = this.world.GetPool<T>();
            return ref pool.Get(this.id);
        }

        public void SetData<T>(T data) where T : struct
        {
            var pool = this.world.GetPool<T>();
            if (pool.Has(this.id))
            {
                pool.Get(this.id) = data;
            }
            else
            {
                pool.Add(this.id) = data;
            }
        }

        public bool TryGetData<T>(out T data) where T : struct
        {
            var pool = this.world.GetPool<T>();
            if (pool.Has(this.id))
            {
                data = pool.Get(this.id);
                return true;
            }

            data = default;
            return false;
        }

        public bool HasData<T>() where T : struct
        {
            var pool = this.world.GetPool<T>();
            return pool.Has(this.id);
        }

        public int GetComponentsNonAlloc(ref object[] components)
        {
            return this.world.GetComponents(this.id, ref components);
        }

        public EcsWorld GetWorld()
        {
            return this.world;
        }
    }
}