using System;
using UnityEngine;

namespace Game.App
{
    [Serializable]
    public struct AnalyticsParameter : ISerializationCallbackReceiver
    {
        [SerializeField]
        public string name;

        [SerializeField]
        public string value;

        public AnalyticsParameter(string name, object value)
        {
            if (string.IsNullOrEmpty(name))
            {
                this.name = AnalyticsConst.UNDEFINED;
            }
            else
            {
                this.name = name;
            }

            if (value == null)
            {
                this.value = AnalyticsConst.UNDEFINED;
            }
            else
            {
                this.value = value.ToString();
            }
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (string.IsNullOrEmpty(this.name))
            {
                this.name = AnalyticsConst.UNDEFINED;
            }

            if (string.IsNullOrEmpty(this.value))
            {
                this.value = AnalyticsConst.UNDEFINED;
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }
    }
}