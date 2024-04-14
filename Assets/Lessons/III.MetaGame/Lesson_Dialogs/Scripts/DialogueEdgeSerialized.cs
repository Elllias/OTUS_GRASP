using System;

namespace Lessons.MetaGame.Dialogs
{
    [Serializable]
    public struct DialogueEdgeSerialized
    {
        public string sourceNode;
        public string targetNode;
        public int index;
    }
}