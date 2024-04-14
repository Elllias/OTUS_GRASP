using Game.Meta;
using Game.Tutorial.Gameplay;
using GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Tutorial
{
    [AddComponentMenu("Tutorial/Step «Upgrade Popup»")]
    public sealed class UpgradePopupController : TutorialStepController
    {
        private readonly UpgradeInspector questInspector = new();

        [SerializeField]
        private UpgradeHeroConfig config;

        [SerializeField]
        private GameObject questCursor;

        [SerializeField]
        private Transform fading;

        [Header("Close")]
        [SerializeField]
        private Button closeButton;

        [SerializeField]
        private GameObject closeCursor;

        private void Awake()
        {
            this.questCursor.SetActive(false);
            this.closeCursor.SetActive(false);
            this.closeButton.interactable = false;
        }

        public override void ConstructGame(GameContext context)
        {
            var upgradesManager = context.GetService<UpgradesManager>();
            this.questInspector.Construct(upgradesManager, this.config);

            base.ConstructGame(context);
        }

        public void Show()
        {
            //Ждем выполнение квеста прокачки:
            this.questInspector.Inspect(this.OnQuestFinished);
            
            //Включаем курсор на прокачке:
            this.questCursor.SetActive(true);
        }

        private void OnQuestFinished()
        {
            //Выключаем курсор на прокачке:
            this.questCursor.SetActive(false);

            //Включаем курсор на кнопке закрыть:
            this.closeCursor.SetActive(true);

            //Делаем затемнение на прокачке:
            this.fading.SetAsLastSibling();

            //Активируем кнопку закрыть:
            this.closeButton.interactable = true;
            this.closeButton.onClick.AddListener(this.OnCloseClicked);
            
            //Завершаем шаг туториала:
            this.NotifyAboutComplete();
        }
        
        private void OnCloseClicked()
        {
            this.closeButton.onClick.RemoveListener(this.OnCloseClicked);
            
            //Выключаем курсор на кнопке закрыть:
            this.closeCursor.SetActive(false);

            //Переходим к следующему шагу туториала:
            this.NotifyAboutMoveNext();
        }
    }
}