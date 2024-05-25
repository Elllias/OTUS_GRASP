using System.Linq;
using Homeworks.PresentationModel.Scripts.Factories;
using Homeworks.PresentationModel.Scripts.UI.View;
using Lessons.Architecture.PM;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Homeworks.PresentationModel.Scripts.UI.Controller
{
    public class CharacteristicContainerViewController
    {
        private const string CHARACTERISTIC_SEPARATOR = ":";
        
        private readonly CharacteristicContainerView _view;
        private readonly CharacterInfo _info;
        
        private readonly CharacteristicViewFactory _characteristicViewFactory;

        public CharacteristicContainerViewController(CharacteristicContainerView view, CharacterInfo info)
        {
            _view = view;
            _info = info;

            _characteristicViewFactory = GetCharacteristicViewFactory();
            
            AddCharacteristics(_info.GetStats());

            _info.OnStatAdded += AddCharacteristic;
            _info.OnStatRemoved += RemoveCharacteristic;
        }

        ~CharacteristicContainerViewController()
        {
            _info.OnStatAdded -= AddCharacteristic;
            _info.OnStatRemoved -= RemoveCharacteristic;
        }
        
        private void AddCharacteristics(CharacterStat[] characterStats)
        {
            foreach (var characterStat in characterStats)
            {
                AddCharacteristic(characterStat);
            }

            _view.RebuildLayout();
        }
        
        private void AddCharacteristic(CharacterStat characterStat)
        {
            var characteristicView = _characteristicViewFactory.SpawnCharacteristicView();

            _view.AddCharacteristic(characteristicView);

            characteristicView.SetName(characterStat.Name + CHARACTERISTIC_SEPARATOR);
            characteristicView.SetValue(characterStat.Value);

            characterStat.OnValueChanged += characteristicView.SetValue;

            _view.RebuildLayout();
        }

        private void RemoveCharacteristic(CharacterStat characteristicStat)
        {
            var characteristicViews = _view.GetCharacteristics();

            var removedCharacteristic =
                characteristicViews.FirstOrDefault(
                    view => view.GetName() == characteristicStat.Name + CHARACTERISTIC_SEPARATOR);

            if (removedCharacteristic == null)
                return;

            _view.RemoveCharacteristic(removedCharacteristic);

            characteristicStat.OnValueChanged -= removedCharacteristic.SetValue;

            Object.Destroy(removedCharacteristic.gameObject);
        }

        private CharacteristicViewFactory GetCharacteristicViewFactory()
        {
            var prefab = _view.GetPrefab();
            var parent = _view.GetParent();

            return new CharacteristicViewFactory(parent, prefab);
        }
    }
}