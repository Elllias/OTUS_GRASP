using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    //PURE FABRICATION
    public interface IProductPresentationModel
    {
        event Action OnStateChanged;

        string GetTitle();
        
        string GetDescription();
        
        Sprite GetIcon();
        
        string GetPrice();
        
        bool CanBuy();
        
        void OnBuyClicked();
        
        void Start();
        
        void Stop();
    }
}