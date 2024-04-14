using System;
using DG.Tweening;
using Declarative;
using UnityEngine;

namespace Game.GameEngine
{
    [Serializable]
    public sealed class UIParryMechanics :
        IEnableListener,
        IDisableListener
    {
        public RectTransform moveTransform;

        private Tween parryTween;

        void IEnableListener.OnEnable()
        {
            this.parryTween = UIAnimations.AnimateParry(this.moveTransform);
        }

        void IDisableListener.OnDisable()
        {
            this.parryTween.Kill();
        }
    }
}