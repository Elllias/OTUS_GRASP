using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    //Менять нельзя!
    public sealed class HeroView : MonoBehaviour
    {
        internal event UnityAction OnClicked
        {
            add { this.button.onClick.AddListener(value); }
            remove { this.button.onClick.RemoveListener(value); }
        }

        [SerializeField]
        private Image heroImage;

        [SerializeField]
        private TMP_Text stats;

        [SerializeField]
        private Button button;

        [Header("Active")]
        [SerializeField, Space]
        private Image activeImage;

        [SerializeField]
        private Sprite activeIcon;

        [SerializeField]
        private Sprite inactiveIcon;

        [SerializeField]
        private GameObject activeBlur;

        [Header("Attack")]
        [SerializeField]
        private RectTransform center;

        [SerializeField]
        private float forwardDuration = 0.2f;

        [SerializeField]
        private AnimationCurve attackCurve;

        [SerializeField]
        private AnimationCurve scaleCurve;

        [SerializeField]
        private float backDuration = 0.5f;

        [SerializeField]
        private AudioClip punchSFX;

        private Sequence attackAnimation;

        private AudioPlayer audioPlayer;
        
        private void Start()
        {
            this.audioPlayer = AudioPlayer.Instance;
        }

        [Sirenix.OdinInspector.Button]
        public void SetIcon(Sprite icon)
        {
            this.heroImage.sprite = icon;
        }

        [Sirenix.OdinInspector.Button]
        public void SetStats(string stats)
        {
            this.stats.text = stats;
        }

        [Sirenix.OdinInspector.Button]
        public void SetActive(bool isActive)
        {
            this.activeImage.sprite = isActive ? this.activeIcon : this.inactiveIcon;
            this.activeBlur.SetActive(isActive);
        }

        [Sirenix.OdinInspector.Button]
        public UniTask AnimateAttack(HeroView target)
        {
            if (this.attackAnimation != null)
            {
                return UniTask.CompletedTask;
            }

            UniTaskCompletionSource tcs = new UniTaskCompletionSource();
            
            Vector3 sourcePosition = this.center.position;
            Vector3 targetPosition = target.center.position;

            this.attackAnimation = DOTween
                .Sequence()
                .Append(this.center.DOMove(targetPosition, this.forwardDuration).SetEase(this.attackCurve))
                .Join(this.center.DOScale(1.25f, this.forwardDuration).SetEase(this.scaleCurve))
                .AppendCallback(() => this.audioPlayer.PlaySound(this.punchSFX))
                .Append(this.center.DOMove(sourcePosition, this.backDuration))
                .Join(this.center.DOScale(1, this.backDuration))
                .OnComplete(() =>
                {
                    this.attackAnimation = null;
                    tcs.TrySetResult();
                });

            return tcs.Task;
        }
    }
}