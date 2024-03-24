using Interface;
using UI.Base;
using UnityEngine;

namespace UI.GameFinishPanel
{
    public class GameFinishViewController : MonoBehaviour, IFinishListener
    {
        private const string FINISH_MESSAGE = "Game Over!";

        [SerializeField] private TextView _textView;

        private void Awake()
        {
            _textView.Hide();
        }
    
        public void OnFinish()
        {
            _textView.SetText(FINISH_MESSAGE);
            _textView.Show();
        }
    }
}