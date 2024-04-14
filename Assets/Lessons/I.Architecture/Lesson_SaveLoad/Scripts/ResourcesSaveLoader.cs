using Game.GameEngine.GameResources;
using Game.Gameplay.Player;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class ResourcesSaveLoader : SaveLoader<ResourceData[], ResourceStorage>
    {
        protected override void SetupData(ResourceStorage store, ResourceData[] data)
        {
            store.Setup(data);
        }

        protected override ResourceData[] ConvertToData(ResourceStorage store)
        {
            return store.GetAllResources();
        }
    }
}