// using UnityEngine;
//
// namespace Lessons.MetaGame.Dialogs
// {
//     public sealed class DialogueTest : MonoBehaviour
//     {
//         [SerializeField]
//         private DialogueConfig config;
//
//         [SerializeField]
//         private int choiceIndex;
//         
//         private Dialogue dialogue;
//         
//         private void Start()
//         {
//             this.dialogue = new Dialogue(this.config);
//             this.PrintDialogue();
//         }
//
//         [ContextMenu("Select Choice")]
//         public void SelectChoice()
//         {
//             if (this.dialogue.MoveNext(this.choiceIndex))
//             {
//                 this.PrintDialogue();
//             }
//             else
//             {
//                 Debug.Log("Dialog finished!");
//             }
//         }
//
//         private void PrintDialogue()
//         {
//             Debug.Log($"MESSAGE: {this.dialogue.CurrentMessage}");
//             Debug.Log($"CHOICES {string.Join('/', this.dialogue.CurrentChoices)}");
//             
//         }
//     }
// }