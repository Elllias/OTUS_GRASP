using UnityEngine;
using UnityEngine.Events;

namespace Lessons.Architecture.MVP
{
    public interface IProductView
    {
        void AddButtonListener(UnityAction action);
        
        void RemoveButtonListener(UnityAction action);
        
        void SetTitle(string title);
        
        void SetDescription(string description);
        
        void SetIcon(Sprite icon);
        
        void SetPrice(string price);
        
        void SetButtonInteractible(bool interactible);
    }
}