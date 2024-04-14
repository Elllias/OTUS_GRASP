using UnityEngine;

namespace Game
{
    [AddComponentMenu("Audio/UISound/UI Sound Component")]
    public class UISoundComponent : MonoBehaviour
    {
        public void PlayEnum(UISoundType soundType)
        {
            UISoundManager.PlaySound(soundType);
        }

        public void PlayClip(AudioClip sound)
        {
            UISoundManager.PlaySound(sound);            
        }
    
        public void Click()
        {
            UISoundManager.PlaySound(UISoundType.CLICK);
        }

        public void Error()
        {
            UISoundManager.PlaySound(UISoundType.ERROR);
        }

        public void Accept()
        {
            UISoundManager.PlaySound(UISoundType.ACCEPT);
        }

        public void Close()
        {
            UISoundManager.PlaySound(UISoundType.CLOSE);
        }

        public void Buy()
        {
            UISoundManager.PlaySound(UISoundType.BUY);
        }

        public void Income()
        {
            UISoundManager.PlaySound(UISoundType.INCOME);
        }

        public void ShowPopup()
        {
            UISoundManager.PlaySound(UISoundType.SHOW_POPUP);
        }
    }
}