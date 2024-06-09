namespace SaveSystem.Interfaces
{
    public interface ISaveService
    {
        void Save(string key, string dataJson);
        string Load(string key);
    }
}