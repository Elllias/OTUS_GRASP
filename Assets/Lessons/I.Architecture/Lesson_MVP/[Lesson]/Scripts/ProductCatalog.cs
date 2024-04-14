using Lessons.Architecture.PM;
using UnityEngine;

namespace Lessons.Architecture.MVP
{
    [CreateAssetMenu(
        fileName = "ProductCatalog",
        menuName = "Lessons/New ProductCatalog"
    )]
    
    
    public sealed class ProductCatalog : ScriptableObject
    {
        [SerializeField]
        public Product[] products;
    }
}