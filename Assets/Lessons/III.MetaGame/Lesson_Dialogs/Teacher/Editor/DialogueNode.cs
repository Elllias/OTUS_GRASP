// using System.Collections.Generic;
// using UnityEditor.Experimental.GraphView;
// using UnityEngine;
// using UnityEngine.UIElements;
//
// namespace Lessons.MetaGame.Dialogs
// {
//     public sealed class DialogueNode : Node
//     {
//         public string Id
//         {
//             get { return this.idText.value; }
//             set { this.idText.value = value; }
//         }
//
//         public string MessageText
//         {
//             get { return this.messageText.value; }
//             set { this.messageText.value = value; }
//         }
//
//         public List<DialogueChoice> Choices
//         {
//             get { return this.choices; }
//         }
//
//         public Port InputPort
//         {
//             get { return this.inputPort; }
//         }
//
//         private readonly List<DialogueChoice> choices = new List<DialogueChoice>();
//         private TextField idText;
//         private TextField messageText;
//         private Port inputPort;
//
//         public DialogueNode(Vector2 posiiton)
//         {
//             this.SetPosition(new Rect(posiiton, Vector2.zero));
//             this.AddId();
//             this.AddChoiceButton();
//             this.AddInputPort();
//             this.AddMessage();
//             this.RefreshExpandedState();
//         }
//
//         private void AddId()
//         {
//             TextField idText = new TextField
//             {
//                 value = "Dialogue Id",
//                 multiline = false
//             };
//
//             idText.AddToClassList("node_id");
//             this.titleContainer.Insert(0, idText);
//             this.idText = idText;
//         }
//
//         private void AddChoiceButton()
//         {
//             var button = new Button
//             {
//                 text = "Add Choice",
//                 clickable = new Clickable(this.CreateChoice),
//             };
//
//             this.mainContainer.Insert(1, button);
//         }
//
//         private void AddInputPort()
//         {
//             this.inputPort = Port.Create<Edge>(
//                 Orientation.Horizontal,
//                 Direction.Input,
//                 Port.Capacity.Multi,
//                 typeof(bool)
//             );
//             this.inputPort.portName = "Input Connection";
//             this.inputContainer.Add(inputPort);
//         }
//
//         private void AddMessage()
//         {
//             TextField message = new TextField
//             {
//                 value = "Dialogue Message",
//                 multiline = true
//             };
//
//             message.AddToClassList("node_message");
//
//             this.extensionContainer.Add(message);
//             this.messageText = message;
//         }
//
//         public void CreateChoice()
//         {
//             this.CreateChoice("Dialogue Choice");
//         }
//
//         public void CreateChoice(string value)
//         {
//             var choice = new DialogueChoice(value, onRemoved: this.DeleteChoice);
//             this.outputContainer.Add(choice.Port);
//             this.choices.Add(choice);
//             this.RefreshExpandedState();
//         }
//
//         public void DeleteChoice(DialogueChoice choice)
//         {
//             this.outputContainer.Remove(choice.Port);
//             this.choices.Remove(choice);
//             this.RefreshExpandedState();
//         }
//     }
// }