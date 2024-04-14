using System;
using UnityEngine;

namespace Game.Meta
{
    public interface IDialoguePresentationModel
    {
        event Action OnStateChanged;

        event Action OnFinished;

        Sprite Icon { get; }
        
        string CurrentMessage { get; }
        
        IOption[] CurrentOptions { get; }

        public interface IOption
        {
            string Text { get; }
            
            void OnSelected();
        }
    }
}