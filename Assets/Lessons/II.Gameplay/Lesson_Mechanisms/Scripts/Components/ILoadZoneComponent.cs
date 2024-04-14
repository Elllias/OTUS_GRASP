namespace Lessons.Gameplay.Mech
{
    public interface ILoadZoneComponent
    {
        bool CanLoad();

        void Load(int resources);
    }
}