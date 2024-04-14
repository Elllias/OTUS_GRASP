using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Enable/Enable Observer «Switch Bool Variable»")]
    public sealed class UEnableObserver_SwitchBoolVariable : UEnableObserver
    {
        [SerializeField]
        public MonoBoolVariable toggle;

        protected override void SetEnable(bool isEnable)
        {
            this.toggle.SetValue(isEnable);
        }
    }
}