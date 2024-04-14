namespace Lessons.Architecture.DI
{
    public interface IInjectProvider
    {
        void Inject(ServiceLocator serviceLocator);
    }
}