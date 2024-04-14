using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Game.GameEngine
{
    public static class UIAnimations
    {
        public static Tween AnimateParry(RectTransform transform)
        {
            var startPositionY = transform.anchoredPosition.y;
            return DOTween
                .Sequence()
                .Append(transform.DOAnchorPosY(startPositionY + 20, 2.5f).SetEase(Ease.InOutSine))
                .Append(transform.DOAnchorPosY(startPositionY, 2.5f).SetEase(Ease.InOutSine))
                .SetLoops(-1);
        }
        
        public static IEnumerator AnimateJumpRoutine(RectTransform particle, JumpSettings[] jumps, float angle)
        {
            var position = particle.anchoredPosition;
            var radAngle = angle * Mathf.Deg2Rad;
            var direction = new Vector2(Mathf.Cos(radAngle) * 1.05f, Mathf.Sin(radAngle) * 0.7f);

            var sequence = DOTween.Sequence();
            for (int i = 0, count = jumps.Length; i < count; i++)
            {
                var jumpInfo = jumps[i];
                position += direction * jumpInfo.distance;
                sequence.Append(particle.DOJumpAnchorPos(position, jumpInfo.power, 1, jumpInfo.duration));
            }

            while (sequence.active)
            {
                yield return null;
            }
        }
        
        public static IEnumerator AnimateFlyRoutine(Transform target, FlySettings settings, Vector3 endPosition)
        {
            AnimationCurve moveCurveOffsetY = settings.offsetY;
            
            var startPosition = target.position;
            var distanceVector = endPosition - startPosition;
            var distance = distanceVector.y;
            
            AnimationCurve scaleCurve = settings.localScale;

            var progress = 0f;
            var duration = settings.duration;
            
            while (progress < 1f)
            {
                var dProgress = Time.deltaTime / duration;
                progress = Mathf.Min(progress + dProgress, 1f);

                //Update particle position:
                var offsetY = moveCurveOffsetY.Evaluate(progress) * distance;
                var offset = new Vector3(0.0f, offsetY, 0.0f);
                var newPosition = Vector3.Lerp(startPosition, endPosition, progress) + offset;
                target.position = newPosition;

                //Update particle scale:
                var localScale = scaleCurve.Evaluate(progress);
                target.localScale = new Vector3(localScale, localScale, 0.0f);

                yield return null;
            }
        }


        
        [Serializable]
        public struct FlySettings
        {
            [SerializeField]
            [Tooltip("Time of particle fly in seconds")]
            public float duration;

            [Space]
            [Tooltip("Relative move offset by Y curve. Keeps values from 0 to 1.")]
            [SerializeField]
            public AnimationCurve offsetY;
        
            [Tooltip("Particle local scale during of flying.")]
            [SerializeField]
            public AnimationCurve localScale;
        }
        
        [Serializable]
        public struct JumpSettings
        {
            [SerializeField]
            public float distance;

            [SerializeField]
            public float power; //100.0f;

            [SerializeField]
            public float duration; //0.25f;
        }
    }
}