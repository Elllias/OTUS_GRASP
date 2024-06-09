namespace SaveSystem.Interfaces
{
    public interface IGameRepository
    {
        void SetData<T>(T data);
        bool TryGetData<T>(out T data);
    }
}