#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Game.GameEngine.UnityEditor
{
    public sealed class DialogueWindow : EditorWindow
    {
        private DialogueGraph graphView;

        private ObjectField dialogField;

        [MenuItem("Window/Dialogue/Dialogue Window")]
        public static void ShowWindow()
        {
            GetWindow<DialogueWindow>("Dialogue Window");
        }

        private void OnEnable()
        {
            this.InitGraphView();
            this.InitToolbar();
        }

        private void InitGraphView()
        {
            this.graphView = new DialogueGraph();
            this.graphView.StretchToParentSize();
            this.rootVisualElement.Add(this.graphView);
        }

        private void InitToolbar()
        {
            this.dialogField = new ObjectField("Selected Dialog")
            {
                objectType = typeof(DialogueConfig),
                allowSceneObjects = false
            };

            var loadButton = new Button
            {
                text = "Load",
                clickable = new Clickable(() =>
                {
                    DialogueManager.LoadDialog(this.graphView, this.dialogField.value as DialogueConfig);
                })
            };

            var saveButton = new Button
            {
                text = "Save",
                clickable = new Clickable(() =>
                {
                    var config = this.dialogField.value as DialogueConfig;
                    if (config != null)
                    {
                        DialogueManager.SaveDialog(this.graphView, config);
                    }
                    else
                    {
                        DialogueManager.CreateDialog(this.graphView, out config);
                        this.dialogField.value = config;
                    }
                })
            };

            var toolbar = new Toolbar();
            toolbar.Add(this.dialogField);
            toolbar.Add(loadButton);
            toolbar.Add(saveButton);

            this.rootVisualElement.Add(toolbar);
        }
    }
}
#endif