// // ///Нарушение принципа OCP.
// //
// //
// //
//      public sealed class UnitSelection {
//          
//          private List<object> selectedUnits;
//
//          public void Attack(GameObject target) {
//              foreach (var unit in selectedUnits) {
//                  if (unit is Archer archer) archer.Shoot(target);
//                  if (unit is Knight knight) knight.Fight(target);
//                  if (unit is Mage mage) mage.Spell(target);
//              }
//          }
//
//          public void Move(Vector3 position) {
//              foreach (var unit in selectedUnits) {
//                  if (unit is Archer archer) archer.Run(position);
//                  if (unit is Knight knight) knight.Move(position);
//                  if (unit is Mage mage) mage.Teleport(position);
//              }
//          }
//      }
//
// //
// //
// // using System.Collections.Generic;
// // using UnityEngine;
// //
// // ///ПРАВИЛЬНОЕ ИСПОЛЬЗОВАНИЕ
// // ///
// //
// //
//      public interface ISelectedUnit {
//          
//          void Move(Vector3 position);
//          void Attack(GameObject target);
//      }
//
//      public sealed class UnitSelection {
//          
//          private List<ISelectedUnit> selectedUnits;
//
//          public void Move(Vector3 position) {
//              foreach (var unit in selectedUnits) {
//                  unit.Move(position);
//              }
//          }
//
//          public void Attack(GameObject target) {
//              foreach (var unit in selectedUnits) {
//                  unit.Attack(target);
//              }
//          }
//      }
// //
// //
// //
// //
// //
// //
// //
// //
// //
// //
// //
// //
// //
// //
// //
// //
// //
// //
// // //     ///OCP пример с абстрактным классом из проекта:
// // //     /// Один раз написали базовую логику и протестировали
// // //     public abstract class Upgrade
// // //     {
// // //         public int Level { get; private set; } = 1;
// // //
// // //         public int MaxLevel => this.config.maxLevel;
// // //
// // //         public int Price { get; }
// // //
// // //         private readonly UpgradeConfig config;
// // //
// // //         protected Upgrade(UpgradeConfig config)
// // //         {
// // //             this.config = config;
// // //         }
// // //
// // //         public void LevelUp()
// // //         {
// // //             if (this.Level >= this.MaxLevel)
// // //             {
// // //                 throw new Exception($"Can not increment level for upgrade {this.config.id}!");
// // //             }
// // //
// // //             var nextLevel = this.Level + 1;
// // //             this.Level = nextLevel;
// // //             this.OnLevelUp(nextLevel); //Шаблонный метод!
// // //         }
// // //
// // //         protected abstract void OnLevelUp(int level);
// // //     }
// // //
// // //     //Нам не придется каждый раз ползать в Upgrades Manager
// // //     // public sealed class UpgradesManager
// // //     // {
// // //     //     public void LevelUpUpgrade(Upgrade upgrade)
// // //     //     {
// // //     //         if (upgrade.Level < upgrade.MaxLevel)
// // //     //         {
// // //     //             this.SpendMoney(upgrade.Price);
// // //     //             upgrade.LevelUp();
// // //     //         }
// // //     //     }
// // //     // }
// // //
// // //
// // //     // /// Затем пишем логику для каждого типа апгрейда
// // //     // public sealed class DamageUpgrade : Upgrade
// // //     // {
// // //     //     public DamageUpgrade(UpgradeConfig config) : base(config)
// // //     //     {
// // //     //     }
// // //     //
// // //     //     protected override void OnLevelUp(int level)
// // //     //     {
// // //     //         //Логика прокачки урона
// // //     //     }
// // //     // }
// // //     // //
// // //     // public sealed class HitPointsUpgrade : Upgrade
// // //     // {
// // //     //     public HitPointsUpgrade(UpgradeConfig config) : base(config)
// // //     //     {
// // //     //     }
// // //     //
// // //     //     protected override void OnLevelUp(int level)
// // //     //     {
// // //     //         //Логика прокачки здоровья
// // //     //     }
// // //     // }
// // //
// // //     // ///OCP пример с интерфейсами:
// // //     // ///Один раз написали общую логику загрузки приложения, и нам не придется каждый раз ползать и дописывать код в ApplicationLoader
// // //    
// // //     
// // //     // public sealed class LoadingTask_LoadGameScene : ILoadingTask
// // //     // {
// // //     //     public Task Do()
// // //     //     {
// // //     //         //Load Game Scene
// // //     //     }
// // //     // }
// // // }
//
//
// //
// // /* Игровой менеджер, который запускает игру по таймеру...
// // public class GameManager : MonoBehaviour
// // {
// //     public event Action OnGameStarted;
// //     public event Action OnGameFinished;
// //
// //     [ReadOnly]
// //     [ShowInInspector]
// //     private readonly List<object> _listeners = new();
// //
// //     [Header("Start Game Timer")]
// //     [SerializeField]
// //     private float _delay;
// //     [SerializeField]
// //     private float _countdown;
// //
// //     private float _startDelay;
// //
// //     private void Awake()
// //     {
// //       _startDelay = _delay;
// //     }
// //     
// //     public void AddListener(object listener)
// //     {
// //         _listeners.Add(listener);
// //     }
// //
// //     public void RemoveListener(object listener)
// //     {
// //         _listeners.Remove(listener);
// //     }
// //
// //     [Button]
// //     public void StartGame()
// //     {
// //         StartCoroutine(StartGameRoutine());
// //         OnGameStarted?.Invoke();
// //     }
// //     
// //     private IEnumerator StartGameRoutine()
// //     {
// //         while (_delay > 0)
// //         {
// //             Debug.Log($"Start in {_delay} second!");
// //             _delay--;
// //             yield return new WaitForSeconds(_countdown);
// //         }
// //
// //         foreach (var listener in _listeners)
// //         {
// //             if (listener is IStartGameListener startListener)
// //             {
// //                 startListener.OnStartGame();
// //             }
// //         }
// //
// //         Debug.Log("Game Started!");
// //     }
// //
// //     [Button]
// //     public void FinishGame()
// //     {
// //         foreach (var listener in _listeners)
// //         {
// //             if (listener is IFinishGameListener finishListener)
// //             {
// //                 finishListener.OnFinishGame();
// //             }
// //         }
// //
// //         Debug.Log("Game Finished!");
// //
// //         _delay = _startDelay;
// //         OnGameFinished?.Invoke();
// //     }
// // }
// // */
// //
// //
// // using System;
// //
// // public class GameStartUp : MonoBehaviour
// // {
// //     public event Action OnCountdownStarted;
// //     
// //     [SerializeField]
// //     private float _delay;
// //    
// //     [SerializeField]
// //     private float _countdown;
// //
// //     private float _startDelay;
// //
// //     [SerializeField]
// //     private GameManager gameManager;
// //
// //     private void Awake()
// //     {
// //         _startDelay = _delay;
// //     }
// //
// //     public void StartUp()
// //     {
// //         StartCoroutine(StartGameRoutine());
// //         OnCountdownStarted?.Invoke();
// //     }
// //     
// //     private IEnumerator StartGameRoutine()
// //     {
// //         while (_delay > 0)
// //         {
// //             Debug.Log($"Start in {_delay} second!");
// //             _delay--;
// //             yield return new WaitForSeconds(_countdown);
// //         }
// //
// //         this.gameManager.StartGame();
// //     }
// // }
// //
// //
// //
// //
// //
// // /* "Универсальный товар магазина"
// // [CreateAssetMenu(fileName = "Shop Product", menuName = "Shop/Product")]
// // public class ShopProduct : ScriptableObject
// // {
// //     [SerializeField]
// //     protected ProductCategory m_category;
// //
// //     [SerializeField]
// //     protected string m_titleCode;
// //
// //     [SerializeField]
// //     protected string m_descCode;
// //
// //     [SerializeField]
// //     protected bool m_isConsumable;
// //
// //     [SerializeField]
// //     protected PaymentType m_paymentType;
// //
// //     [SerializeField]
// //     protected string m_inAppCode;
// //
// //     [SerializeField]
// //     protected int m_price;
// //
// //     [SerializeField]
// //     protected Sprite m_iconSprite;
// //
// //     public ProductCategory category
// //     {
// //         get { return m_category; }
// //     }
// //
// //     public string titleCode
// //     {
// //         get { return m_titleCode; }
// //     }
// //
// //     public string descCode
// //     {
// //         get { return m_descCode; }
// //     }
// //
// //     public bool isConsumable
// //     {
// //         get { return m_isConsumable; }
// //     }
// //
// //     public PaymentType paymentType
// //     {
// //         get { return m_paymentType; }
// //     }
// //
// //     public string inAppCode
// //     {
// //         get { return m_inAppCode; }
// //     }
// //
// //     public virtual int price
// //     {
// //         get { return m_price; }
// //     }
// //
// //     public Sprite iconSprite
// //     {
// //         get { return m_iconSprite; }
// //     }
// //
// //     public bool isPurchased
// //     {
// //         get { return IsPurchased(); }
// //     }
// //
// //     public bool isRealPayment
// //     {
// //         get { return paymentType.Equals(PaymentType.RealCurrency); }
// //     }
// //
// //     public bool isADPayment
// //     {
// //         get { return paymentType.Equals(PaymentType.ADCurrency); }
// //     }
// //
// //     public int countOfViewAD { get; protected set; }
// //
// //     public delegate void PurchaseResultHandler(ShopProduct product, bool success);
// //
// //     public event PurchaseResultHandler OnPurchaseResult;
// //
// //     protected string prefKey
// //     {
// //         get { return string.Format("PREF_KEY_{0}", titleCode); }
// //     }
// //
// //     protected string prefKeyAdViews
// //     {
// //         get { return string.Format("{0}_AD_VIEWS", prefKey); }
// //     }
// //
// //     protected const bool SUCCESS = true;
// //     protected const bool FAIL = false;
// //
// //     public virtual void Initialize()
// //     {
// //     }
// //
// //     protected virtual bool IsPurchased()
// //     {
// //         if (isConsumable)
// //             return false;
// //
// //         if (isRealPayment)
// //             return IsPurchasedRealPayment();
// //
// //         if (price == 0) // Если цена = 0, то предмет куплен.
// //             return true;
// //
// //         return IsNonConsumablePurchased();
// //     }
// //
// //     protected bool IsPurchasedRealPayment()
// //     {
// //         return InAppPurchaser.instance.IsPurchased(this);
// //     }
// //
// //     protected bool IsNonConsumablePurchased()
// //     {
// //         return PlayerPrefs.GetBool(prefKey, false);
// //     }
// //
// //     public virtual void Purchase()
// //     {
// //         if (!isPurchased)
// //         {
// //             switch (paymentType)
// //             {
// //                 case PaymentType.ADCurrency:
// //                     PurchaseForADCurrency();
// //                     break;
// //                 case PaymentType.SoftCurrency:
// //                     PurchaseForSoftCurrency();
// //                     break;
// //                 case PaymentType.RealCurrency:
// //                     PurchaseForRealCurrency();
// //                     break;
// //                 case PaymentType.HardCurrency:
// //                     PurchaseForHardCurrency();
// //                     break;
// //             }
// //         }
// //         else
// //         {
// //             NotifyAboutPurchaseResults(FAIL);
// //         }
// //     }
// //
// //     protected void PurchaseForRealCurrency()
// //     {
// //         InAppPurchaser.OnPurchaseResult += InAppPurchaser_OnPurchaseResult;
// //         InAppPurchaser.instance.Purchase(this);
// //     }
// //
// //     protected void InAppPurchaser_OnPurchaseResult(ShopProduct product, bool success)
// //     {
// //         InAppPurchaser.OnPurchaseResult -= InAppPurchaser_OnPurchaseResult;
// //         if (product == this)
// //         {
// //             if (success)
// //                 PurchaseSuccess();
// //             else
// //                 PurchaseFail();
// //         }
// //     }
// //
// //     protected virtual void PurchaseForADCurrency()
// //     {
// //         ADS.instance.ShowRewardedVideo(ADS_OnRewardedVideoResult);
// //     }
// //
// //     protected virtual void ADS_OnRewardedVideoResult(ADSResults results)
// //     {
// //         if (results.success)
// //         {
// //             AddViewsAD();
// //             Debug.Log(string.Format("AD payment success: ", countOfViewAD));
// //             if (countOfViewAD >= price)
// //             {
// //                 PurchaseSuccess();
// //                 countOfViewAD = 0;
// //             }
// //             else
// //             {
// //                 PurchaseFail();
// //             }
// //         }
// //         else
// //         {
// //             PurchaseFail();
// //         }
// //     }
// //
// //     protected virtual void AddViewsAD()
// //     {
// //         countOfViewAD++;
// //         PlayerPrefs.SetInt(prefKeyAdViews, countOfViewAD);
// //     }
// //
// //     protected virtual void PurchaseForSoftCurrency()
// //     {
// //         if (Bank.IsEnoughSoftCurrency(price))
// //         {
// //             PurchaseSuccess();
// //             Bank.SpendSoftCurrency(price);
// //         }
// //         else
// //             PurchaseFail();
// //     }
// //
// //     protected virtual void PurchaseForHardCurrency()
// //     {
// //         if (Bank.IsEnoughHardCurrency(price))
// //         {
// //             PurchaseSuccess();
// //             Bank.SpendHardCurrency(price);
// //         }
// //         else
// //             PurchaseFail();
// //     }
// //
// //     protected virtual void PurchaseSuccess()
// //     {
// //         if (!isConsumable)
// //             PlayerPrefs.SetBool(prefKey, true);
// //         NotifyAboutPurchaseResults(SUCCESS);
// //     }
// //
// //     private void NotifyAboutPurchaseResults(bool success)
// //     {
// //         if (OnPurchaseResult != null)
// //             OnPurchaseResult(this, success);
// //     }
// //
// //     protected virtual void PurchaseFail()
// //     {
// //         NotifyAboutPurchaseResults(FAIL);
// //     }
// //
// //     public virtual string GetPrice()
// //     {
// //         if (isRealPayment)
// //             return InAppPurchaser.instance.GetPrice(this);
// //         if (isADPayment)
// //             return GetADPrice();
// //         return price.ToString();
// //     }
// //
// //     protected virtual string GetADPrice()
// //     {
// //         return (price - countOfViewAD).ToString();
// //     }
// //
// //     [ContextMenu("Reset Info")]
// //     public virtual void Reset()
// //     {
// //         PlayerPrefs.SetInteger(prefKey, 0);
// //         PlayerPrefs.SetInteger(prefKeyAdViews, 0);
// //         Debug.Log(string.Format("{0} product was cleaned", titleCode));
// //     }
// //
// //     public virtual string GetTitle()
// //     {
// //         return titleCode;
// //     }
// //
// //     public virtual string GetDescription()
// //     {
// //         return descCode;
// //     }
// //
// //     public void ForcePurchase()
// //     {
// //         PurchaseSuccess();
// //     }
// // }
// // */
// //
// //
// //
// // [CreateAssetMenu(fileName = "Shop Product", menuName = "Shop/Product")]
// // public class ShopProduct : ScriptableObject
// // {
// //     [SerializeField]
// //     protected ProductCategory m_category;
// //
// //     [SerializeField]
// //     protected string m_titleCode;
// //
// //     [SerializeField]
// //     protected string m_descCode;
// //
// //     [SerializeField]
// //     protected bool m_isConsumable;
// //
// //     [SerializeField]
// //     protected PaymentType m_paymentType;
// //
// //     [SerializeField]
// //     protected string m_inAppCode;
// //
// //     [SerializeField]
// //     protected int m_price;
// //
// //     [SerializeField]
// //     protected Sprite m_iconSprite;
// //
// //     public ProductCategory category
// //     {
// //         get { return m_category; }
// //     }
// //
// //     public string titleCode
// //     {
// //         get { return m_titleCode; }
// //     }
// //
// //     public string descCode
// //     {
// //         get { return m_descCode; }
// //     }
// //
// //     public bool isConsumable
// //     {
// //         get { return m_isConsumable; }
// //     }
// //
// //     public PaymentType paymentType
// //     {
// //         get { return m_paymentType; }
// //     }
// //
// //     public string inAppCode
// //     {
// //         get { return m_inAppCode; }
// //     }
// //
// //     public virtual int price
// //     {
// //         get { return m_price; }
// //     }
// //
// //     public Sprite iconSprite
// //     {
// //         get { return m_iconSprite; }
// //     }
// //
// //     public bool isPurchased
// //     {
// //         get { return IsPurchased(); }
// //     }
// //
// //     public bool isRealPayment
// //     {
// //         get { return paymentType.Equals(PaymentType.RealCurrency); }
// //     }
// //
// //     public bool isADPayment
// //     {
// //         get { return paymentType.Equals(PaymentType.ADCurrency); }
// //     }
// //
// //     public int countOfViewAD { get; protected set; }
// //
// //     public delegate void PurchaseResultHandler(ShopProduct product, bool success);
// //
// //     public event PurchaseResultHandler OnPurchaseResult;
// //
// //     protected string prefKey
// //     {
// //         get { return string.Format("PREF_KEY_{0}", titleCode); }
// //     }
// //
// //     protected string prefKeyAdViews
// //     {
// //         get { return string.Format("{0}_AD_VIEWS", prefKey); }
// //     }
// //
// //     protected const bool SUCCESS = true;
// //     protected const bool FAIL = false;
// //
// //     public virtual void Initialize()
// //     {
// //     }
// //
// //     protected virtual bool IsPurchased()
// //     {
// //         if (isConsumable)
// //             return false;
// //
// //         if (isRealPayment)
// //             return IsPurchasedRealPayment();
// //
// //         if (price == 0) // Если цена = 0, то предмет куплен.
// //             return true;
// //
// //         return IsNonConsumablePurchased();
// //     }
// //
// //     protected bool IsPurchasedRealPayment()
// //     {
// //         return InAppPurchaser.instance.IsPurchased(this);
// //     }
// //
// //     protected bool IsNonConsumablePurchased()
// //     {
// //         return PlayerPrefs.GetBool(prefKey, false);
// //     }
// //
// //     public virtual void Purchase()
// //     {
// //         if (!isPurchased)
// //         {
// //             switch (paymentType)
// //             {
// //                 case PaymentType.ADCurrency:
// //                     PurchaseForADCurrency();
// //                     break;
// //                 case PaymentType.SoftCurrency:
// //                     PurchaseForSoftCurrency();
// //                     break;
// //                 case PaymentType.RealCurrency:
// //                     PurchaseForRealCurrency();
// //                     break;
// //                 case PaymentType.HardCurrency:
// //                     PurchaseForHardCurrency();
// //                     break;
// //             }
// //         }
// //         else
// //         {
// //             NotifyAboutPurchaseResults(FAIL);
// //         }
// //     }
// //
// //     protected void PurchaseForRealCurrency()
// //     {
// //         InAppPurchaser.OnPurchaseResult += InAppPurchaser_OnPurchaseResult;
// //         InAppPurchaser.instance.Purchase(this);
// //     }
// //
// //     protected void InAppPurchaser_OnPurchaseResult(ShopProduct product, bool success)
// //     {
// //         InAppPurchaser.OnPurchaseResult -= InAppPurchaser_OnPurchaseResult;
// //         if (product == this)
// //         {
// //             if (success)
// //                 PurchaseSuccess();
// //             else
// //                 PurchaseFail();
// //         }
// //     }
// //
// //     protected virtual void PurchaseForADCurrency()
// //     {
// //         ADS.instance.ShowRewardedVideo(ADS_OnRewardedVideoResult);
// //     }
// //
// //     protected virtual void ADS_OnRewardedVideoResult(ADSResults results)
// //     {
// //         if (results.success)
// //         {
// //             AddViewsAD();
// //             Debug.Log(string.Format("AD payment success: ", countOfViewAD));
// //             if (countOfViewAD >= price)
// //             {
// //                 PurchaseSuccess();
// //                 countOfViewAD = 0;
// //             }
// //             else
// //             {
// //                 PurchaseFail();
// //             }
// //         }
// //         else
// //         {
// //             PurchaseFail();
// //         }
// //     }
// //
// //     protected virtual void AddViewsAD()
// //     {
// //         countOfViewAD++;
// //         PlayerPrefs.SetInt(prefKeyAdViews, countOfViewAD);
// //     }
// //
// //     protected virtual void PurchaseForSoftCurrency()
// //     {
// //         if (Bank.IsEnoughSoftCurrency(price))
// //         {
// //             PurchaseSuccess();
// //             Bank.SpendSoftCurrency(price);
// //         }
// //         else
// //             PurchaseFail();
// //     }
// //
// //     protected virtual void PurchaseForHardCurrency()
// //     {
// //         if (Bank.IsEnoughHardCurrency(price))
// //         {
// //             PurchaseSuccess();
// //             Bank.SpendHardCurrency(price);
// //         }
// //         else
// //             PurchaseFail();
// //     }
// //
// //     protected virtual void PurchaseSuccess()
// //     {
// //         if (!isConsumable)
// //             PlayerPrefs.SetBool(prefKey, true);
// //         NotifyAboutPurchaseResults(SUCCESS);
// //     }
// //
// //     private void NotifyAboutPurchaseResults(bool success)
// //     {
// //         if (OnPurchaseResult != null)
// //             OnPurchaseResult(this, success);
// //     }
// //
// //     protected virtual void PurchaseFail()
// //     {
// //         NotifyAboutPurchaseResults(FAIL);
// //     }
// //
// //     public virtual string GetPrice()
// //     {
// //         if (isRealPayment)
// //             return InAppPurchaser.instance.GetPrice(this);
// //         if (isADPayment)
// //             return GetADPrice();
// //         return price.ToString();
// //     }
// //
// //     protected virtual string GetADPrice()
// //     {
// //         return (price - countOfViewAD).ToString();
// //     }
// //
// //     [ContextMenu("Reset Info")]
// //     public virtual void Reset()
// //     {
// //         PlayerPrefs.SetInteger(prefKey, 0);
// //         PlayerPrefs.SetInteger(prefKeyAdViews, 0);
// //         Debug.Log(string.Format("{0} product was cleaned", titleCode));
// //     }
// //
// //     public virtual string GetTitle()
// //     {
// //         return titleCode;
// //     }
// //
// //     public virtual string GetDescription()
// //     {
// //         return descCode;
// //     }
// //
// //     public void ForcePurchase()
// //     {
// //         PurchaseSuccess();
// //     }
// // }
// //
// //
// //
// // public class RewardApplier
// // {
// //     private HardCurrencyRewardApplier hardCurrencyRewardApplier;
// //     private SoftCurrencyRewardApplier softCurrencyRewardApplier;
// //     private ItemRewardApplier itemRewardApplier;
// //
// //     [Inject]
// //     public void Construct(
// //         HardCurrencyRewardApplier hardCurrencyRewardApplier,
// //         SoftCurrencyRewardApplier softCurrencyRewardApplier,
// //         ItemRewardApplier itemRewardApplier
// //     )
// //     {
// //         this.hardCurrencyRewardApplier = hardCurrencyRewardApplier;
// //         this.softCurrencyRewardApplier = softCurrencyRewardApplier;
// //         this.itemRewardApplier = itemRewardApplier;
// //     }
// //     
// //     public void ApplyReward(IReward reward)
// //     {
// //         switch (reward)
// //         {
// //             case SoftCurrencyReward softCurrencyReward:
// //                 this.softCurrencyRewardApplier.ApplyReward(softCurrencyReward);
// //                 break;
// //             case HardCurrencyReward hardCurrencyReward:
// //                 this.hardCurrencyRewardApplier.ApplyReward(hardCurrencyReward);
// //                 break;
// //             case ItemReward itemReward:
// //                 this.itemRewardApplier.ApplyReward(itemReward);
// //                 break;
// //         }
// //     }
// // }
// //
//
//
//      