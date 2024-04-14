using DG.Tweening;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class UIParryAnimatorMono : MonoBehaviour
    {
        [SerializeField]
        private RectTransform moveTransform;

        private Tween parryTween;
        
        private void OnEnable()
        {
            this.parryTween = UIAnimations.AnimateParry(this.moveTransform);
        }

        private void OnDisable()
        {
            this.parryTween.Kill();
        }
    }
}