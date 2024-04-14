using UnityEngine;
using UnityEngine.Events;

namespace Lessons.Architecture.PM
{
    public class Popup : MonoBehaviour
    {
        private ICallback callback;

        [SerializeField]
        private UnityEvent<object> onShow;

        [SerializeField]
        private UnityEvent onHide;
        
        public void Show(object args = null, ICallback callback = null)
        {
            this.callback = callback;
            this.OnShow(args);
            this.onShow?.Invoke(args);
        }

        public void Hide()
        {
            this.OnHide();
            this.onHide?.Invoke();
        }

        protected virtual void OnShow(object args)
        {
        }

        protected virtual void OnHide()
        {
        }

        public void RequestClose()
        {
            this.callback?.OnClose(this);
        }

        public interface ICallback
        {
            void OnClose(Popup popup);
        }
    }
}