using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Homeworks.PresentationModel.Scripts.UI.View
{
    public class UserDescriptionView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TMP_Text _level;

        public void SetIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
        }
    
        public void SetDescription(string description)
        {
            _description.text = description;
        }
        
        public void SetLevelText(string levelText)
        {
            _level.text = levelText;
        }
    }
}
