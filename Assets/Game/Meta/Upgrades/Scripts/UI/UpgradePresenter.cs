using Game.App;
using Game.Gameplay.Player;
using Game.Localization;
using UnityEngine;

namespace Game.Meta
{
    public sealed class UpgradePresenter
    {
        private const string UPGRADE_COLOR_HEX = "309D1E";

        private readonly Upgrade upgrade;

        private readonly UpgradeView view;

        private UpgradesManager upgradesManager;

        private MoneyStorage moneyStorage;

        public UpgradePresenter(Upgrade upgrade, UpgradeView view)
        {
            this.upgrade = upgrade;
            this.view = view;
        }

        public void Construct(UpgradesManager upgradesManager, MoneyStorage moneyStorage)
        {
            this.upgradesManager = upgradesManager;
            this.moneyStorage = moneyStorage;
        }

        public void Start()
        {
            this.view.SetIcon(this.upgrade.Metadata.icon);
            this.view.UpgradeButton.AddListener(this.OnButtonClicked);

            this.upgrade.OnLevelUp += this.OnLevelUp;
            this.moneyStorage.OnMoneyChanged += this.OnMoneyChanged;

            var language = LanguageManager.CurrentLanguage;
            this.UpdateTitle(language);
            this.UpdateLevel(language);
            this.UpdateStats(language);
            this.UpdateButtonPrice();
            this.UpdateButtonState();
            LanguageManager.OnLanguageChanged += this.OnUpdateLanguage;
        }

        public void Stop()
        {
            this.view.UpgradeButton.RemoveListener(this.OnButtonClicked);
            this.upgrade.OnLevelUp -= this.OnLevelUp;
            this.moneyStorage.OnMoneyChanged -= this.OnMoneyChanged;
            LanguageManager.OnLanguageChanged -= this.OnUpdateLanguage;
        }

        #region UIEvents

        private void OnButtonClicked()
        {
            if (this.upgradesManager.CanLevelUp(this.upgrade))
            {
                this.upgradesManager.LevelUp(this.upgrade);
            }
        }

        #endregion

        #region ModelEvents

        private void OnLevelUp(int level)
        {
            var language = LanguageManager.CurrentLanguage;
            this.UpdateLevel(language);
            this.UpdateStats(language);
            this.UpdateButtonPrice();
            this.UpdateButtonState();
        }

        private void OnMoneyChanged(int newValue)
        {
            this.UpdateButtonState();
        }

        private void OnUpdateLanguage(SystemLanguage language)
        {
            this.UpdateTitle(language);
            this.UpdateLevel(language);
            this.UpdateStats(language);
        }

        #endregion

        private void UpdateTitle(SystemLanguage language)
        {
            var titleKey = this.upgrade.Metadata.localizedTitle;
            var title = LocalizationManager.GetText(titleKey, language);
            this.view.SetTitle(title);
        }

        private void UpdateLevel(SystemLanguage language)
        {
            var title = LocalizationManager.GetText(LocalizationKeys.Common.LEVEL_KEY, language);
            var levelText = $"{title}: {this.upgrade.Level}/{this.upgrade.MaxLevel}";
            this.view.SetLevel(levelText);
        }
        
        private void UpdateStats(SystemLanguage language)
        {
            var title = LocalizationManager.GetText(LocalizationKeys.Common.VALUE_KEY, language);
            var statsText = $"{title}: {this.upgrade.CurrentStats}";
            
            if (!this.upgrade.IsMaxLevel)
            {
                statsText += $" <color=#{UPGRADE_COLOR_HEX}>(+{this.upgrade.NextImprovement})</color>";
            }
            
            this.view.SetStats(statsText);
        }

        private void UpdateButtonPrice()
        {
            var priceText = this.upgrade.NextPrice.ToString();
            this.view.UpgradeButton.SetPrice(priceText);
        }

        private void UpdateButtonState()
        {
            var upgradeButton = this.view.UpgradeButton;
            if (this.upgrade.IsMaxLevel)
            {
                upgradeButton.SetState(UpgradeButton.State.MAX);
                return;
            }

            var state = this.upgrade.NextPrice <= this.moneyStorage.Money
                ? UpgradeButton.State.AVAILABLE
                : UpgradeButton.State.LOCKED;

            upgradeButton.SetState(state);
        }
    }
}