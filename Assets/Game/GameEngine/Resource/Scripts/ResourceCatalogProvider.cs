using UnityEngine;

namespace Game.GameEngine.GameResources
{
    public sealed class ResourceCatalogProvider : MonoBehaviour
    {
        public ResourceInfoCatalog Catalog
        {
            get { return this.catalog; }
        }

        [SerializeField]
        private ResourceInfoCatalog catalog;
    }
}