using System;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class Dialogue
    {
        public Sprite Icon
        {
            get { return this.config.icon; }
        }
        
        public string CurrentMessage
        {
            get { return this.currentNode.content; }
        }

        public string[] CurrentChoices
        {
            get { return this.currentNode.choices; }
        }

        private readonly DialogueConfig config;

        private DialogueConfig.Node currentNode;

        public Dialogue(DialogueConfig config)
        {
            if (!config.FindEntryNode(out var node))
            {
                throw new Exception("Entry point is absent!");
            }

            this.config = config;
            this.currentNode = node;
        }

        public bool MoveNext(int choiceIndex)
        {
            if (this.config.FindNextNode(this.currentNode.id, choiceIndex, out var nextNode))
            {
                this.currentNode = nextNode;
                return true;
            }

            return false;
        }
    }
}