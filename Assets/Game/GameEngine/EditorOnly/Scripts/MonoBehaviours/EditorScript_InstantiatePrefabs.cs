#if UNITY_EDITOR
using UnityEngine;

namespace Game.GameEngine.Development
{
    public class EditorScript_InstantiatePrefabs : MonoBehaviour
    {
        [SerializeField]
        private Transform container;
        
        [SerializeField]
        private GameObject[] prefabs;

        public void InstantiatePrefabs()
        {
            for (int i = 0, count = this.prefabs.Length; i < count; i++)
            {
                var prefab = this.prefabs[i];
                Instantiate(prefab, this.container);
            }
        }
    }
}
#endif