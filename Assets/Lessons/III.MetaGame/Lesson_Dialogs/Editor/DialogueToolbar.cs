#if UNITY_EDITOR
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Lessons.MetaGame.Dialogs
{
    public sealed class DialogueToolbar : Toolbar
    {
        private readonly DialogueGraph graph;
        private ObjectField dialogField;

        public DialogueToolbar(DialogueGraph graph)
        {
            this.graph = graph;
            this.AddDialogField();
            this.AddLoadButton();
            this.AddSaveButton();
            this.AddResetButton();
        }
        
        private void AddDialogField()
        {
            this.dialogField = new ObjectField("Selected Dialog")
            {
                objectType = typeof(DialogueConfig),
                allowSceneObjects = false
            };
            
            this.Add(this.dialogField);
        }

        private void AddLoadButton()
        {
            var button = new Button
            {
                text = "Load",
                clickable = new Clickable(this.OnLoadDialog)
            };
            
            this.Add(button);
        }

        private void AddSaveButton()
        {
            var button = new Button
            {
                text = "Save",
                clickable = new Clickable(this.OnSaveDialog)
            };
            
            this.Add(button);
        }
        
        private void AddResetButton()
        {
            var button = new Button
            {
                text = "Reset",
                clickable = new Clickable(this.OnResetDialog)
            };
            
            this.Add(button);
        }

        private void OnLoadDialog()
        {
            this.graph.Reset();
            DialogueSaveLoader.LoadDialog(this.dialogField.value as DialogueConfig, this.graph);
        }

        private void OnSaveDialog()
        {
            var config = this.dialogField.value as DialogueConfig;
            if (config != null)
            {
                DialogueSaveLoader.SaveDialog(this.graph, config);
            }
            else
            {
                DialogueSaveLoader.CreateDialog(this.graph, out config);
                this.dialogField.value = config;
            }
        }
        
        private void OnResetDialog()
        {
            this.graph.Reset();
        }
    }
}
#endif