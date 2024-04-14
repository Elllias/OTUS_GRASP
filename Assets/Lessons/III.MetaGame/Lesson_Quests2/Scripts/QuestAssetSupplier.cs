using Game.App;
using UnityEngine;

namespace Lessons.Meta
{
    public sealed class QuestAssetSupplier : IConfigLoader
    {
        private const string CATALOG_PATH = "QuestCatalog";

        private QuestCatalog catalog;
        
        public QuestConfig GetQuest(string id)
        {
            return this.catalog.FindQuest(id);
        }

        public QuestConfig[] GetAllQuests()
        {
            return this.catalog.GetAllQuests();
        }

        void IConfigLoader.LoadConfigs()
        {
            this.catalog = Resources.Load<QuestCatalog>(CATALOG_PATH);
        }
    }
}