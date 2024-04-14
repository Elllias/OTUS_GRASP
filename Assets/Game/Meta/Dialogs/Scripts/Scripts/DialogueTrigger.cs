using Game.GameEngine;
using UnityEngine;

namespace Game.Meta
{
    [RequireComponent(typeof(Collider))]
    public sealed class DialogueTrigger : MonoBehaviour
    {
        public DialogueConfig Dialogue
        {
            get { return this.dialogue; }
        }

        [SerializeField]
        private DialogueConfig dialogue;
    }
}