namespace Lessons.Gameplay.Mech
{
    public interface IUnloadZoneComponent
    {
        bool CanUnload();
    
        int UnloadAll();
    }
}