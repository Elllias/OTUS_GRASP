using UnityEngine;

namespace Lessons.MetaGame.Dialogs
{
    public sealed class DialogueTest : MonoBehaviour
    {
        [SerializeField]
        private DialogueConfig config;
        private Dialogue dialogue;

        [SerializeField]
        private int choiceIndex;

        private void Start()
        {
            this.dialogue = new Dialogue(this.config);
            this.PrintDialog();
        }

        [ContextMenu("Select Choice")]
        public void SelectChoice()
        {
            if (this.dialogue.MoveNext(this.choiceIndex))
            {
                this.PrintDialog();
            }
            else
            {
                Debug.Log("Dialog finished!");
            }
        }
        
        private void PrintDialog()
        {
            Debug.Log("----");
            Debug.Log($"Message: {this.dialogue.CurrentMessage}");

            foreach (var choice in dialogue.CurrentChoices)
            {
                Debug.Log($"Choice: {choice}");
            }
            
            Debug.Log("----");
        }
    }
}