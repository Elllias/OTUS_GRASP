using UnityEngine;

namespace GameEngine
{
    //Нельзя менять!
    public sealed class Resource : MonoBehaviour
    {
        public string ID
        {
            get => id;
        }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        [SerializeField]
        private string id;

        [SerializeField]
        private int amount;
    }
}