using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public interface IEffectParameter
    {
        EffectId Name { get; }
    }

    public interface IEffectParameter<out T> : IEffectParameter
    {
        T Value { get; }
    }

    [Serializable]
    public abstract class AbstractEffectParameter<T> : IEffectParameter<T>
    {
        public EffectId Name
        {
            get { return this.name; }
        }

        public T Value
        {
            get { return this.value; }
        }

        [SerializeField]
        private EffectId name;

        [SerializeField]
        private T value;

        public AbstractEffectParameter()
        {
        }

        public AbstractEffectParameter(EffectId name, T value)
        {
            this.name = name;
            this.value = value;
        }
    }

    [Serializable]
    public sealed class IntEffectParameter : AbstractEffectParameter<int>
    {
        public IntEffectParameter()
        {
        }

        public IntEffectParameter(EffectId name, int value) : base(name, value)
        {
        }
    }

    [Serializable]
    public sealed class FloatEffectParameter : AbstractEffectParameter<float>
    {
        public FloatEffectParameter()
        {
        }

        public FloatEffectParameter(EffectId name, float value) : base(name, value)
        {
        }
    }

    [Serializable]
    public sealed class StringEffectParameter : AbstractEffectParameter<string>
    {
        public StringEffectParameter()
        {
        }

        public StringEffectParameter(EffectId name, string value) : base(name, value)
        {
        }
    }
}