using Homeworks.PresentationModel.Scripts.UI.View;
using UnityEngine;

namespace Homeworks.PresentationModel.Scripts.Fabrics
{
    public class CharacteristicViewFabric
    {
        private readonly Transform _parent;
        private readonly CharacteristicView _prefabView;

        public CharacteristicViewFabric(Transform parent, CharacteristicView prefabView)
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