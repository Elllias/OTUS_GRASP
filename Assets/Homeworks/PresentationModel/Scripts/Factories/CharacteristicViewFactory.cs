using Homeworks.PresentationModel.Scripts.UI.View;
using UnityEngine;

namespace Homeworks.PresentationModel.Scripts.Factories
{
    public class CharacteristicViewFactory
    {
        private readonly Transform _parent;
        private readonly CharacteristicView _prefabView;

        public CharacteristicViewFactory(Transform parent, CharacteristicView prefabView)
        {
            _parent = parent;
            _prefabView = prefabView;
        }

        public CharacteristicView SpawnCharacteristicView()
        {
            var view = Object.Instantiate(_prefabView, _parent);
            return view;
        }
    }
}