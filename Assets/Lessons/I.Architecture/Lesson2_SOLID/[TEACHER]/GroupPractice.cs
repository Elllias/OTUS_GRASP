// //SRP:
//
//
//
// using System;
// using System.Threading.Tasks;
// using UnityEngine;
//
//
//
//     public enum PaymentType
//     {
//         SoftCurrency,
//         HardCurrency,
//         IAP,
//         ADS
//     }
//
//
//     public sealed class ShopProduct : ScriptableObject
//     {
//         [SerializeField]
//         private string m_titleCode;
//
//         [SerializeField]
//         private string m_descCode;
//         
//         [SerializeField]
//         private Sprite m_iconSprite;
//         
//         [SerializeField]
//         private PaymentType m_paymentType;
//
//         [SerializeField]
//         private int m_softCurrencyPrice;
//
//         [SerializeField]
//         private int m_hardCurrencyPrice;
//
//         [SerializeField]
//         private string m_inAppProductId;
//
//         public async Task<bool> Purchase()
//         {
//             return m_paymentType switch
//             {
//                 PaymentType.ADS => await WatchAds(),
//                 PaymentType.SoftCurrency => this.SpendSoftCurrency(),
//                 PaymentType.IAP => await PurchaseIAP(),
//                 PaymentType.HardCurrency => SpendHardCurrency(),
//                 _ => throw new ArgumentOutOfRangeException()
//             };
//         }
//
//         private async Task<bool> WatchAds()
//         {
//             var result = await AdsManager.ShowRewardedVideo();
//             return result.success;
//         }
//
//         private Task<bool> PurchaseIAP()
//         {
//             var result = await IAPManager.Purchase(this);
//             return result.success;
//         }
//
//         private bool SpendSoftCurrency()
//         {
//             return MoneyBank.TrySpendSoftCurrency(m_softCurrencyPrice);
//         }
//         
//         private bool SpendHardCurrency()
//         {
//             return MoneyBank.TrySpendHardCurrency(m_softCurrencyPrice);
//         }
//     }
//
//
//
// //Цель практики отрефакторить код в группах:
// //Потом студенты показывают, что у них получилось )))
//
// //Пример №1: SRP
// // public class SpawnAndClickSystem : MonoBehaviour {
// //     
// //     [SerializeField] private GameObject prefab;
// //     [SerializeField] private Transform spawnPoint;
// //     [SerializeField] private float spawnRadius;
// //
// //     public GameObject SpawnObject() {
// //         var spawnPosition = this.spawnPoint.position + Random.onUnitSphere * this.spawnRadius;
// //         return Instantiate(this.prefab, spawnPosition, Quaternion.identity);
// //     }
// //
// //     public bool ClickObject(out GameObject unit) {
// //         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
// //         if (Physics.Raycast(ray, out var hit)) {
// //             unit = hit.transform.gameObject;
// //             return true;
// //         }
// //
// //         unit = default;
// //         return false;
// //     }
// // }
//
// //Пример №2: ISP
// // public interface IOrk
// // {
// //     int HitPoints { get; }
// //     void Move(Vector3 direction);
// //     void DealDamage(GameObject target);
// //     void TakeDamage(int damage);
// // }
//
// //Пример №3: 
// //OCP:
// // public sealed class BulletPool {
// //     
// //     private readonly Queue<Bullet> _bullets;
// //
// //     public BulletPool(Bullet pref, int size) {
// //         _bullets = new Queue<Bullet>(size);
// //         for (var i = 0; i < size; i++) {
// //             this._bullets.Enqueue(GameObject.Instantiate(pref));
// //         }
// //     }
// //
// //     public Bullet Get() {
// //         return _bullets.Dequeue();
// //     }
// //
// //     public void Release(Bullet item) {
// //         return _bullets.Enqueue(item);
// //     }
// // }
//
// // public sealed class EnemyPool {
// //     
// //     private readonly Queue<Enemy> enemies;
// //
// //     public EnemyPool(Enemy prefab, int size) {
// //         this.enemies = new Queue<Enemy>(size);
// //         for (var i = 0; i < size; i++) {
// //             this.enemies.Enqueue(GameObject.Instantiate(prefab));
// //         }
// //     }
// //
// //     public Enemy PullEnemy() {
// //         return this.enemies.Dequeue();
// //     }
// //
// //     public void ReleaseEnemy(Enemy item)
// //     {
// //         return this.enemies.Enqueue(item);
// //     }
// // }
//
// //Пример №4: SRP
// // public class PlayerMonoBeh : MonoBehaviour {
// //     
// //     public int Hp;
// //     public int Speed;
// //
// //     public void MovePlayerInDirection(Vector3 dir) {
// //         this.transform.position += dir * this.Speed;
// //     }
// //
// //     public void DealDamage(int damag) {
// //         this.Hp -= damag;
// //     }
// //
// //     public void Save() {
// //         PlayerPrefs.SetInt("hitPoints", this.Hp);
// //         PlayerPrefs.SetInt("speed", this.Speed);
// //     }
// //
// //     public void LoadFromPrefs() {
// //         this.Hp = PlayerPrefs.GetInt("hitPoints");
// //         this.Speed = PlayerPrefs.GetInt("speed");
// //     }
// // }
//
//
// //Пример №5: DIP
// // public sealed class QuestSystem {
// //     
// //     public event Action<UnityQuest> OnQuestStarted;
// //     public event Action<UnityQuest> OnQuestCompleted;
// //
// //     private UnityQuest quest;
// //     private QuestGenerator generator;
// //     
// //     public void StartNewQuest() {
// //         UnityQuest quest = this.generator.GenerateQuest();
// //
// //         this.quest = quest;
// //         this.quest.OnCompleted += this.OnCompleteQuest;
// //
// //         this.quest.Start();
// //         this.OnQuestStarted?.Invoke(quest);
// //     }
// //
// //     private void OnCompleteQuest(UnityQuest quest) {
// //         this.quest.OnCompleted -= this.OnCompleteQuest;
// //         this.OnQuestCompleted?.Invoke(quest);
// //     }
// // }
//
// //Пример №6: OCP
// // public sealed class GameSaver
// // {
// //     private Hero hero;
// //     private Enemies enemies;
// //     private Quests quests;
// //     private Inventory inventory;
// //
// //     private HttpClient client;
// //
// //     public async void Save()
// //     {
// //         var sb = new StringBuilder()
// //             .Append(JsonUtility.ToJson(this.hero))
// //             .Append(JsonUtility.ToJson(this.enemies))
// //             .Append(JsonUtility.ToJson(this.quests))
// //             .Append(JsonUtility.ToJson(this.inventory));
// //
// //         await this.client.RequestPut("https://www.otus.ru/unity-pro/game-data", sb.ToString());
// //     }
// // }
//
// //Пример №7:
// //Тут все ок)
// // public sealed class CameraFollower : MonoBehaviour,
// //     IGameStartListener,
// //     IGameFinishListener
// // {
// //     [SerializeField]
// //     private Vector3 offset;
// //     
// //     private IHero hero;
// //     private Transform cameraTransform;
// //
// //     private void Awake()
// //     {
// //         this.enabled = false;
// //     }
// //
// //     private void LateUpdate()
// //     {
// //         this.cameraTransform.position = this.hero.position + this.offset;
// //     }
// //
// //     [Inject]
// //     public void Construct(IHero hero, Camera camera)
// //     {
// //         this.hero = hero;
// //         this.cameraTransform = camera.transform;
// //     }
// //
// //     void IGameStartElement.StartGame()
// //     {
// //         this.enabled = true;
// //     }
// //
// //     void IGameFinishElement.FinishGame()
// //     {
// //         this.enabled = false;
// //     }
// // }
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
// //
// // public class AIController
// // {
// //     private UnityObject
// // }
// //
// // public class GameClock
// // {
// //     private UnityTimer timer;
// // }
//
//
// //
// // public class ProductPurchaser
// // {
// //     public void PurchaseProduct(ScriptableProduct scriptableProduct)
// //     {
// //         scriptableProduct.name;
// //         scriptableProduct.scriptableProduct.price
// //     }
// // }
// //
// // public sealed class Client
// // {
// //     private TcpServer server;
// //
// //     public Client(TcpServer server)
// //     {
// //         this.server = server;
// //         this.server.SetIP("127.0.0.1");
// //         this.server.SetPort(8000);
// //     }
// //
// //     public async Task SignIn(string login, string password)
// //     {
// //         var data = $"{login} {password}";
// //         var response = await this.server.Send(data);
// //         if (response == "Success")
// //         {
// //         }
// //     }
// // }
// //
// //
// // public sealed class GameSaveSystem
// // {
// //     private readonly unitect client;
// //
// //     public async Task<string> SaveGame()
// //     {
// //         var 
// //
// //         if (client is HttpClient httpClient)
// //         {
// //             return httpClient.Request(data);
// //         }
// //
// //         if (client is TcpClient tcpClient)
// //         {
// //             return tcpClient.Send(data);
// //         }
// //
// //         if (client is SshClient sshClient)
// //         {
// //             return sshClient.Push(data);
// //         }
// //
// //         throw new Exception("Undefined client!");
// //     }
// // }
// //
// // public class HttpClient
// // {
// // }
// //
// // public class TcpClient
// // {
// // }
// //
// // public class SshClient
// // {
// // }
// //
// //
// // //Пример №4: SRP
//
//
//
//
// // public sealed class SelectedUnitStack : IFixedTickable
// // {
// //     public event Action OnStateChanged;
// //     
// //     private readonly HashSet<Unit> units = new();
// //     private readonly List<Unit> cache = new();
// //     
// //     public void Add(Unit unit)
// //     {
// //         this.units.Add(unit);
// //         this.OnStateChanged?.Invoke();
// //     }
// //
// //     public void Remove(Unit unit)
// //     {
// //         this.units.Remove(unit);
// //         this.OnStateChanged?.Invoke();
// //     }
// //     
// //     public IEnumerable<Unit> GetUnits()
// //     {
// //         return this.units;
// //     }
// //
// //     void IFixedTickable.IFixedTick()
// //     {
// //         this.cache.Clear();
// //         this.cache.AddRange(this.units);
// //
// //         for (int i = 0, count = this.cache.Count; i < count; i++)
// //         {
// //             var unit = this.cache[i];
// //             if (!unit.IsAlive())
// //             {
// //                 this.Remove(unit);
// //             }
// //         }
// //     }
// // }
//
// using System;
// using UnityEngine;
// using Random = UnityEngine.Random;
//
// public sealed class PlayerController : Singleton<PlayerController>
// {
//     public void Initialize() {
//         Singleton<IMoveInput>.Instance.OnMove += this.OnMove;
//     }
//
//     public void Dispose() {
//         Singleton<IMoveInput>.Instance.OnMove -= this.OnMove;
//     }
//
//     private void OnMove(Vector3 direction) {
//         Singleton<IPlayer>.Instance.MoveTowards(direction);
//     }
// }
//
// public abstract class Singleton<T> where T : class
// {
//     public static T Instance { get; private set; }
//     
//     protected Singleton()
//     {
//         Instance = this as T;
//     }
// }
//
// public interface IPlayer
// {
//     void MoveTowards(Vector3 direction);
// }
//
// public interface IMoveInput
// {
//     event Action<Vector3> OnMove;
// }
//
//
//
//
// public sealed class QuestFactory
// {
//     private readonly DependencyInjector injector;
//
//     public QuestFactory(DependencyInjector injector)
//     {
//         this.injector = injector;
//     }
//
//     public Quest InstantiateQuest(QuestConfig config)
//     {
//         var quest = config.InstatiateQuest();
//         injector.Inject(quest);
//         return quest;
//     }
// }
//
// public sealed class QuestSelector
// {
//     private readonly QuestConfig[] questPool;
//
//     public QuestSelector(QuestConfig[] questPool)
//     {
//         this.questPool = questPool;
//     }
//
//     public QuestConfig SelectQuestConfig()
//     {
//         var randomIndex = Random.Range(0, this.questPool.Length);
//         return this.questPool[randomIndex];
//     }
// }
//
// public sealed class QuestService
// {
//     public Quest CurrentQuest { get; set; }
// }
//
// public sealed class QuestGiver
// {
//     private readonly QuestSelector selector;
//     private readonly QuestFactory factory;
//     private readonly QuestService service;
//
//     public QuestGiver(QuestSelector selector, QuestFactory factory, QuestService service)
//     {
//         this.selector = selector;
//         this.factory = factory;
//         this.service = service;
//     }
//
//     public void GiveNewQuest()
//     {
//         var questConfig = this.selector.SelectQuestConfig();
//         var quest = this.factory.InstantiateQuest(questConfig);
//         this.service.CurrentQuest = quest;
//         this.service.CurrentQuest.Start();
//     }
// }
//
// public sealed class QuestRewardReceiver
// {
//     private readonly MoneyStorage moneyStorage;
//     private readonly QuestService service;
//
//     public QuestRewardReceiver(MoneyStorage moneyStorage, QuestService service)
//     {
//         this.moneyStorage = moneyStorage;
//         this.service = service;
//     }
//
//     public void ReceiveReward()
//     {
//         var quest = this.ActiveQuest;
//         if (quest is {IsCompleted: true})
//         {
//             this.moneyStorage.EarnMoney(quest.MoneyReward);
//             quest.Dispose();
//             this.service.CurrentQuest = null;
//         }
//     }
// }

//
// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using Random = UnityEngine.Random;
//
// public sealed class PistolWeapon : MonoBehaviour
// {
//     [SerializeField]
//     public int currentBullets;
//
//     [SerializeField]
//     public int maxBullets;
//
//     private GameObject bulletPrefab;
//     private float bulletSpreadAngle;
//
//     [SerializeField]
//     private float fireDuration = 0.75f;
//     private float fireCountdown;
//
//     [SerializeField]
//     private Transform firePoint;
//
//     [SerializeField]
//     private ParticleSystem fireVFX;
//
//     [SerializeField]
//     private AudioClip fireSFX;
//
//     private IBulletSpawner bulletSpawner;
//     private IAudioManager audioManager;
//     private IAnalyticsManager analyticsManager;
//     private IPlayerLevel playerLevel;
//     
//     public void Construct(
//         IBulletSpawner bulletSpawner,
//         IAudioManager audioManager,
//         IAnalyticsManager analyticsManager,
//         IPlayerLevel playerLevel
//     )
//     {
//         this.bulletSpawner = bulletSpawner;
//         this.audioManager = audioManager;
//         this.analyticsManager = analyticsManager;
//         this.playerLevel = playerLevel;
//     }
//
//     public bool CanFire()
//     {
//         return this.currentBullets > 0 &&
//                this.fireCountdown <= 0;
//     }
//
//     public void Fire()
//     {
//         if (!this.CanFire())
//         {
//             return;
//         }
//
//         var prevBullets = this.currentBullets;
//         this.currentBullets--;
//         var spreadAngle = Random.Range(-this.bulletSpreadAngle, this.bulletSpreadAngle);
//         var position = this.firePoint.position;
//         var rotation = this.firePoint.rotation * Quaternion.Euler(0, spreadAngle, 0);
//         this.bulletSpawner.Spawn(this.bulletPrefab, position, rotation);
//         this.fireCountdown = this.fireDuration;
//         this.fireVFX.Play(withChildren: true);
//         this.audioManager.Play(this.fireSFX);
//         this.analyticsManager.LogEvent("PistolFire", new Dictionary<string, object>
//         {
//             {"pistol_bullets", prevBullets},
//             {"player_level", this.playerLevel.Value}
//         });
//     }
// }
//
//
// public class ClickAndSpawnObject : MonoBehaviour
// {
//     [SerializeField]
//     private GameObject prefab;
//
//     [SerializeField]
//     private ObjectManager objectManager;
//     
//     private void Update() {
//         if (!Input.GetMouseButtonDown(0)) {
//             return;
//         }
//     
//         var ray = Camera.main!.ScreenPointToRay(Input.mousePosition);
//         if (!Physics.Raycast(ray, out var hit)) {
//             return;
//         }
//         
//         if (!hit.transform.CompareTag("Ground")) {
//             return;
//         }
//         
//         var obj = Instantiate(this.prefab, hit.point, Quaternion.identity);
//         this.objectManager.RegisterObject(obj);
//     }
// }
//
//
//
//
//
//
// public sealed class SelectedUnitStackController : IInitializable, IDisposable
// {
//     private readonly SelectedUnitStack stack;
//     private readonly ObjectSelection objectSelection;
//
//     public SelectedUnitStackController(SelectedUnitStack stack, ObjectSelection objectSelection)
//     {
//         this.stack = stack;
//         this.objectSelection = objectSelection;
//     }
//
//     public void Initialize()
//     {
//         this.objectSelection.OnStateChanged += this.OnObjectsChanged;
//     }
//
//     public void Dispose()
//     {
//         this.objectSelection.OnStateChanged += this.OnObjectsChanged;
//     }
//
//     private void OnObjectsChanged(IEnumerable<int> objects)
//     {
//         var playerObjects = this.FilterPlayerObjects(objects);
//         this.stack.Update(playerObjects);
//     }
//
//     private IEnumerable<int> FilterPlayerObjects(IEnumerable<int> objects)
//     {
//         foreach (var obj in objects)
//         {
//             if (this.objectHelper.IsPlayer(obj, this.playerId))
//             {
//                 yield return obj;
//             }
//         }
//     }
// }