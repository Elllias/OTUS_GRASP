using UnityEngine;

namespace Game.GameEngine.Products
{
    public interface IProductMetadata
    {
         public Sprite Icon { get; }

         public string Title { get; }

         public string Decription { get; }
    }
}