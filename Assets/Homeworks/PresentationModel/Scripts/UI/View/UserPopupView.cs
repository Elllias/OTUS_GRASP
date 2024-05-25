using System;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Homeworks.PresentationModel.Scripts.UI.View
{
    public class UserPopupView : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
