// using System;
// using UnityEditor.Experimental.GraphView;
// using UnityEngine;
// using UnityEngine.UIElements;
//
// namespace Lessons.MetaGame.Dialogs
// {
//     public sealed class DialogueChoice
//     {
//         public Port Port
//         {
//             get { return this.port; }
//         }
//
//         public string Text
//         {
//             get { return this.choiceText.value; }
//         }
//
//         private Port port;
//         private TextField choiceText;
//
//         public DialogueChoice(string value, Action<DialogueChoice> onRemoved)
//         {
//             this.AddPort();
//             this.AddChoiceText(value);
//             this.AddDeleteButton(onRemoved);
//         }
//
//         private void AddPort()
//         {
//             this.port = Port.Create<Edge>(
//                 Orientation.Horizontal,
//                 Direction.Output,
//                 Port.Capacity.Multi,
//                 typeof(bool)
//             );
//
//             this.port.portName = string.Empty;
//             this.port.portColor = Color.cyan;
//         }
//
//         private void AddChoiceText(string value)
//         {
//             this.choiceText = new TextField
//             {
//                 value = value,
//                 multiline = false
//             };
//
//             this.choiceText.AddToClassList("node_choice");
//             this.port.Add(this.choiceText);
//         }
//
//         private void AddDeleteButton(Action<DialogueChoice> onRemoved)
//         {
//             var deleteButton = new Button
//             {
//                 text = "X",
//                 clickable = new Clickable(() => onRemoved?.Invoke(this))
//             };
//
//             this.port.Add(deleteButton);
//         }
//     }
// }