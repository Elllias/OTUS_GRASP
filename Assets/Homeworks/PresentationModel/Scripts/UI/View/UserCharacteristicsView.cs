using System.Collections.Generic;
using Lessons.Architecture.PM;
using UnityEngine;

namespace Homeworks.PresentationModel.Scripts.UI.View
{
    public class UserCharacteristicsView : MonoBehaviour
    {
        [SerializeField] private CharacteristicView _characteristicViewPrefab;
        [SerializeField] private RectTransform _characteristicParent;
        
        private List<CharacteristicView> _characteristicViews;

        private void Awake()
        {
            _characteristicViews = new List<CharacteristicView>();
        }

        public void AddCharacteristic(CharacteristicView characteristicView)
        {
            _characteristicViews.Add(characteristicView);
        }

        public void RemoveCharacteristic(CharacteristicView characteristicView)
        {
            _characteristicViews.Remove(characteristicView);
        }

        public Transform GetCharacteristicParent()
        {
            return _characteristicParent;
        }

        public CharacteristicView GetPrefab()
        {
            return _characteristicViewPrefab;
        }

        public List<CharacteristicView> GetCharacteristics()
        {
            return _characteristicViews;
        }

        public void RebuildLayout()
        {
            // К сожалению, из за ContentSizeFilter нужен этот костыль.
            _characteristicParent.ForceUpdateRectTransforms();
            Canvas.ForceUpdateCanvases();
        }
    }
}
