using UnityEngine;

namespace Elementary
{
    internal sealed class MonoHelper : MonoBehaviour
    {
        internal static MonoHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateInstance();
                }

                return _instance;
            }
        }
        
        private static MonoHelper _instance;

        private static MonoHelper CreateInstance()
        {
            var gameObject = new GameObject("MonoContext")
            {
                hideFlags = HideFlags.HideInHierarchy
            };
            
            DontDestroyOnLoad(gameObject);
            return gameObject.AddComponent<MonoHelper>();
        }
    }
}