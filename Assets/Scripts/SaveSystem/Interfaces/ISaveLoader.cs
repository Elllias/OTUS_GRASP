namespace SaveSystem.Interfaces
{
    public interface ISaveLoader
    {
        void Save(IGameRepository repository);
        void Load(IGameRepository repository);
    }
}