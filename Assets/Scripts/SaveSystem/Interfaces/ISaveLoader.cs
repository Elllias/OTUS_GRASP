namespace SaveSystem.Interfaces
{
    internal interface ISaveLoader<in TService>
    {
        void Save(TService service);
        void Load(TService service);
    }
}