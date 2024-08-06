using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Create ItemConfig", fileName = "ItemConfig", order = 1)]
    public class ItemConfig : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public int Id;
    }
}