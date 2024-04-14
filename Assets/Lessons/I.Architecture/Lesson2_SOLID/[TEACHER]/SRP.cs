// // Нарушение SRP
// // public sealed class Player : MonoBehaviour
// // {
// //     [SerializeField] private float speed;
// //
// //     private void Update() {
// //         if (Input.GetKey(KeyCode.UpArrow)) {
// //             this.Move(Vector3.up);
// //         }
// //         else if (Input.GetKey(KeyCode.DownArrow)) {
// //             this.Move(Vector3.down);
// //         }
// //         
// //         if (Input.GetKey(KeyCode.LeftArrow)) {
// //             this.Move(Vector3.left);
// //         }
// //         else if (Input.GetKey(KeyCode.RightArrow)) {
// //             this.Move(Vector3.right);
// //         }
// //     }
// //
// //     private void Move(Vector3 direction) {
// //         this.transform.position += direction * Time.deltaTime * this.speed;
// //         this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
// //     }
// // }
//
//
// using UnityEngine;
//
using UnityEngine;

        // public sealed class Player : MonoBehaviour
        // {
        //     [SerializeField] private float speed;
        //     
        //     private void Update() {
        //         if (Input.GetKey(KeyCode.UpArrow)) {
        //             this.Move(Vector3.up);
        //         }
        //         else if (Input.GetKey(KeyCode.DownArrow)) {
        //             this.Move(Vector3.down);
        //         }
        //          
        //         if (Input.GetKey(KeyCode.LeftArrow)) {
        //             this.Move(Vector3.left);
        //         }
        //         else if (Input.GetKey(KeyCode.RightArrow)) {
        //             this.Move(Vector3.right);
        //         }
        //     }
        //     
        //     private void Move(Vector3 direction) {
        //         this.transform.position += direction * Time.deltaTime * this.speed;
        //         this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        //     }
        // }



 //
 //
     public sealed class Player : MonoBehaviour
     {
         [SerializeField] private float speed;
     
         public void Move(Vector3 direction) {
             this.transform.position += direction * Time.deltaTime * this.speed;
             this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
         }
     }
   
     public sealed class MoveController : MonoBehaviour
     {
         [SerializeField] private Player player;
         [SerializeField] private MoveInput moveInput;
         
         private void Update() {
             this.player.Move(this.moveInput.GetDirection());
         }
     }



    public sealed class MoveInput : MonoBehaviour
    {
        public Vector3 GetDirection() {
            if (Input.GetKey(KeyCode.UpArrow)) {
                return Vector3.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow)) {
                return Vector3.down;
            } else if (Input.GetKey(KeyCode.LeftArrow)) {
                return Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) {
                return Vector3.right;
            }
            return Vector3.zero;
        }
    }




//
//
//
//
//
//
//
// //
// // using System;
// // using UnityEngine;
// //
// //     ///Правильное SRP
// //     
// //     public sealed class MoveComponent : MonoBehaviour {
// //         
// //         [SerializeField] private float speed;
// //     
// //         public void Move(Vector3 direction) {
// //             this.transform.position += direction * this.speed;
// //             this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
// //         }
// //     }
// //     
// //     
// //     public sealed class MoveInput : MonoBehaviour
// //     {
// //         public event Action<Vector3> OnMove; 
// //
// //         private void Update() {
// //             if (Input.GetKey(KeyCode.UpArrow)) 
// //                 this.OnMove?.Invoke(Vector3.up * Time.deltaTime);
// //             else if (Input.GetKey(KeyCode.DownArrow)) 
// //                 this.OnMove?.Invoke(Vector3.down * Time.deltaTime);
// //
// //             if (Input.GetKey(KeyCode.LeftArrow))
// //                 this.OnMove?.Invoke(Vector3.left * Time.deltaTime);
// //             else if (Input.GetKey(KeyCode.RightArrow)) 
// //                 this.OnMove?.Invoke(Vector3.right * Time.deltaTime);
// //         }
// //     }
// //     
// //     // public sealed class MoveController : MonoBehaviour
// //     // {
// //     //     [SerializeField] private MoveInput moveInput;
// //     //     [SerializeField] private MoveComponent moveable;
// //     //
// //     //     private void OnEnable() => this.moveInput.OnMove += this.moveable.Move;
// //     //     private void OnDisable() => this.moveInput.OnMove -= this.moveable.Move;
// //     // }
// //     //
// //
// //


/*
 * Адаптер, который обрабатывает все события в игре
 */


//
// using UnityEngine;
//
// public class Adapter : MonoBehaviour
// {
//     [SerializeField] private GameStateMachine _gameStateMachine;
//     [SerializeField] private PlayerHealth _playerHealth;   
//     [SerializeField] private InputSystem _keyBoard;
//     [SerializeField] private PlayerMove _playerMove;
//     
//     [SerializeField] private ButtonHandler _buttonStart;
//     [SerializeField] private ButtonHandler _buttonPause;
//     [SerializeField] private ButtonHandler _buttonRestart;
//     
//     [SerializeField] private Enemy[] _enemies;
//
//     private void OnEnable()
//     {
//         AddFinishListners();
//         AddEnemyListners();
//         AddKeyBoardPlayerListner();
//         AddButtonStartListner();
//         AddButtonPauseListner();
//         AddButtonRestartListner();
//     }
//
//     private void OnDisable()
//     {
//         RemoveFinishListners();
//         RemoveEnemyListners();
//         RemoveKeyBoardPlayerListner();
//         RemoveButtonStartListner();
//         RemoveButtonPauseListner();
//         RemoveButtonRestartListner();
//     }
//
//     private void AddFinishListners()
//     {
//         _playerHealth.OnDeth += _gameStateMachine.FinishGame;
//     }
//
//     private void RemoveFinishListners()
//     {
//         _playerHealth.OnDeth += _gameStateMachine.FinishGame;
//     }
//
//     private void AddEnemyListners()
//     {
//         foreach (var enemy in _enemies)     
//            enemy.OnEnemyHit += _playerHealth.TakeDamege;
//     }
//
//     private void RemoveEnemyListners()
//     {
//         foreach (var enemy in _enemies)
//            enemy.OnEnemyHit -= _playerHealth.TakeDamege;    
//     }
//
//     private void AddKeyBoardPlayerListner()
//     {
//         _keyBoard.OnPressedInputButton += _playerMove.SetDirection;
//     }
//
//     private void RemoveKeyBoardPlayerListner()
//     {
//         _keyBoard.OnPressedInputButton -= _playerMove.SetDirection;
//     }
//
//     private void AddButtonStartListner()
//     {
//         _buttonStart.OnClick += _gameStateMachine.StartGame;
//     }
//
//     private void RemoveButtonStartListner()
//     {
//         _buttonStart.OnClick -= _gameStateMachine.StartGame;
//     }
//
//     private void AddButtonPauseListner()
//     {
//         _buttonPause.OnClick += _gameStateMachine.StartGame;
//     }
//
//
//     private void RemoveButtonPauseListner()
//     {
//         _buttonPause.OnClick -= _gameStateMachine.StartGame;
//     }
//
//     private void AddButtonRestartListner()
//     {
//         _buttonRestart.OnClick += _gameStateMachine.StartGame;
//     }
//
//
//     private void RemoveButtonRestartListner()
//     {
//         _buttonRestart.OnClick -= _gameStateMachine.StartGame;
//     }
// }
//
//
//
// public sealed class GameFinishObserver : MonoBehaviour
// {
//     [SerializeField] private GameStateMachine _gameStateMachine;
//     [SerializeField] private PlayerHealth _playerHealth;   
//     
//     private void OnEnable()
//     {
//         _playerHealth.OnDeth += _gameStateMachine.FinishGame;
//     }
//
//     private void OnDisable()
//     {
//         _playerHealth.OnDeth += _gameStateMachine.FinishGame;
//     }
// }
//
// public sealed class EnemyHitObserver : MonoBehaviour
// {
//     [SerializeField] private Enemy[] _enemies;
//     [SerializeField] private PlayerHealth _playerHealth;   
//     
//     private void OnEnable()
//     {
//         foreach (var enemy in _enemies)     
//             enemy.OnEnemyHit += _playerHealth.TakeDamege;
//     }
//
//     private void OnDisable()
//     {
//         foreach (var enemy in _enemies)
//             enemy.OnEnemyHit -= _playerHealth.TakeDamege;    
//     }
// }
//
//
// public sealed class PlayerMoveController : MonoBehaviour
// {
//     [SerializeField] private InputSystem _keyBoard;
//     [SerializeField] private PlayerMove _playerMove;
//
//     private void OnEnable()
//     {
//         _keyBoard.OnPressedInputButton += _playerMove.SetDirection;
//     }
//
//     private void OnDisable()
//     {
//         _keyBoard.OnPressedInputButton -= _playerMove.SetDirection;
//     }
// }
//
//
//
// public class ScreenButtonsListener : MonoBehaviour
// {
//     [SerializeField] private ButtonHandler _buttonStart;
//     [SerializeField] private ButtonHandler _buttonPause;
//     [SerializeField] private ButtonHandler _buttonRestart;
//     
//     [SerializeField] private GameStateMachine _gameStateMachine;
//
//     private void OnEnable()
//     {
//         _buttonStart.OnClick += _gameStateMachine.StartGame;
//         _buttonPause.OnClick += _gameStateMachine.StartGame;
//         _buttonRestart.OnClick += _gameStateMachine.StartGame;
//     }
//
//     private void OnDisable()
//     {
//         _buttonStart.OnClick -= _gameStateMachine.StartGame;
//         _buttonPause.OnClick -= _gameStateMachine.StartGame;
//         _buttonRestart.OnClick -= _gameStateMachine.StartGame;
//     }
// }



/* Спавнер врагов, который дополнительно считает врагов
public class EnemySpawnObserver : IStartGameListener, ILoseGameListener
{
    private EnemySpawner _enemySpawner;
    private Player _player;
    private ScoreManager _scoreManager;
    private Dictionary<LifeComponent, Action> _enemyDeathHandlers = new();


    [Inject]
    public void Construct(EnemySpawner enemySpawner, PlayerEntity playerEntity, ScoreManager scoreManager)
    {
        _enemySpawner = enemySpawner;
        _playerEntity = playerEntity;
        _scoreManager = scoreManager;
    }

    public void OnStartGame() => _enemySpawner.OnEnemySpawned += InstallEnemy;
    public void OnLoseGame() => _enemySpawner.OnEnemySpawned -= InstallEnemy;

    private void InstallEnemy(Enemy enemy)
    {
        enemy.Get<TargetComponent>().SetTarget(_playerEntity);

        LifeComponent currentLifeComponent = enemy.Get<LifeComponent>();
        Action deathHandler = () =>
        {
            _scoreManager.AddKillsScore();
            currentLifeComponent.OnDeath -= _enemyDeathHandlers[currentLifeComponent];
            _enemyDeathHandlers.Remove(currentLifeComponent);
        };

        currentLifeComponent.OnDeath += deathHandler;
        _enemyDeathHandlers[currentLifeComponent] = deathHandler;
    }
}
*/



/* Система пуль, которая все делает с пулями в том числе и пуллинг
public sealed class BulletSystem : MonoBehaviour, IGameStartListener, IGameFixedUpdateListener
{
    [SerializeField]
    private int initialCount = 50;
    
    [SerializeField] private Transform container;
    [SerializeField] private Bullet prefab;
    [SerializeField] private Transform worldTransform;
    
    private BulletLevelBounds _levelBounds;
    private readonly Queue<Bullet> m_bulletPool = new();
    private readonly HashSet<Bullet> m_activeBullets = new();
    private readonly List<Bullet> m_cache = new();

    [Inject]
    public void Construct(BulletLevelBounds levelBounds)
    {
        _levelBounds = levelBounds;
    }

    void IGameStartListener.OnStartGame()
    {
        for (var i = 0; i < initialCount; i++)
        {
            var bullet = Instantiate(prefab, container);
            m_bulletPool.Enqueue(bullet);
        }
    }

    public void OnFixedUpdate(float deltaTime)
    {
        m_cache.Clear();
        m_cache.AddRange(m_activeBullets);

        for (int i = 0, count = m_cache.Count; i < count; i++)
        {
            var bullet = m_cache[i];
            if (!_levelBounds.InBounds(bullet.transform.position))
            {
                RemoveBullet(bullet);
            }
        }
    }

    public void FlyBulletByArgs(Args args) //  
    {
        if (m_bulletPool.TryDequeue(out var bullet))
        {
            bullet.transform.SetParent(worldTransform);
        }
        else
        {
            bullet = Instantiate(prefab, worldTransform);
        }

        bullet.SetPosition(args.position);
        bullet.SetColor(args.color);
        bullet.SetPhysicsLayer(args.physicsLayer);
        bullet.damage = args.damage;
        bullet.isPlayer = args.isPlayer;
        bullet.SetVelocity(args.velocity);
        
        if (m_activeBullets.Add(bullet))
        {
            bullet.OnCollisionEntered += OnBulletCollision;
        }
    }
    
    private void OnBulletCollision(Bullet bullet, Collision2D collision)
    {
        BulletUtils.DealDamage(bullet, collision.gameObject);
        RemoveBullet(bullet);
    }

    private void RemoveBullet(Bullet bullet)
    {
        if (m_activeBullets.Remove(bullet))
        {
            bullet.OnCollisionEntered -= OnBulletCollision;
            bullet.transform.SetParent(container);
            m_bulletPool.Enqueue(bullet);
        }
    }

    public struct Args
    {
        public Vector2 position;
        public Vector2 velocity;
        public Color color;
        public int physicsLayer;
        public int damage;
        public bool isPlayer;
    }
}
*/








//////////////////////////////////////////////////////////////////////

/* Жирный попап персонажа, UI можно подразбить
public class CharacterPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _expText;
    [SerializeField] private Image _expBar;
    [SerializeField] private Button _lvlupButton;
    [SerializeField] private Transform _statsParent;
    [SerializeField] private CharacterStatObserver _characterStatPrefab;
    
    private ICharacterPresenter _characterPresenter;
    
    public void Show(ICharacterPresenter characterPresenter)
    {
        this._characterPresenter = characterPresenter;
        
        _levelText.text = _characterPresenter.GetLevel();
        _expText.text = _characterPresenter.GetExperience();
        _expBar.sprite = _characterPresenter.GetProgressBarSprite();
        _expBar.fillAmount = _characterPresenter.GetProgressBarFill();
        _lvlupButton.interactable = _characterPresenter.CanLvlUp();
        _lvlupButton.image.sprite = _characterPresenter.GetLvlupButtonSprite();
        _lvlupButton.onClick.AddListener(_characterPresenter.OnLvlupClicked);
        foreach (var stat in _characterPresenter.GetAllStats())
            StatAdded(stat);

        _characterPresenter.OnLvlChanged += LvlChanged;
        _characterPresenter.OnExpChanged += ExpChanged;
        _characterPresenter.OnStatAdded += StatAdded;
        _characterPresenter.OnStatRemoved += StatRemoved;
        
        _characterPresenter.Begin();
    }

    public void Hide()
    {
        _lvlupButton.onClick.RemoveListener(_characterPresenter.OnLvlupClicked);
        
        _characterPresenter.OnLvlChanged -= LvlChanged;
        _characterPresenter.OnExpChanged -= ExpChanged;
        _characterPresenter.OnStatAdded -= StatAdded;
        _characterPresenter.OnStatRemoved -= StatRemoved;
        foreach (var stat in _characterPresenter.GetAllStats())
            StatRemoved(stat);
        
        _characterPresenter.Stop();
        this._characterPresenter = null;
    }

    private void LvlChanged()
    {
        _levelText.text = _characterPresenter.GetLevel();
        ExpChanged();
    }
    
    private void ExpChanged()
    {
        _expText.text = _characterPresenter.GetExperience();
        _expBar.sprite = _characterPresenter.GetProgressBarSprite();
        _expBar.fillAmount = _characterPresenter.GetProgressBarFill();
        _lvlupButton.interactable = _characterPresenter.CanLvlUp();
        _lvlupButton.image.sprite = _characterPresenter.GetLvlupButtonSprite();
    }

    private void StatAdded(CharacterStat stat)
    {
        var newStat = Instantiate(_characterStatPrefab, Vector3.zero, Quaternion.identity, _statsParent);
        newStat.Init(stat);
        newStat.transform.localPosition = Vector3.zero;
    }
    
    private void StatRemoved(CharacterStat stat)
    {
        for (int i = 0; i < _statsParent.childCount; i++)
        {
            if (_statsParent.GetChild(i).GetComponent<CharacterStatObserver>().Stat == stat)
            {
                Destroy(_statsParent.GetChild(i).gameObject);
                return;
            }
        }
    }
}
*/


/* Класс гонка, которая управляет и героем и противниками и обратным отсчетом
public sealed class Race : AbstractBehaviour, IOnUpdate
{
    public RaceTrigger Trigger;
    public int Laps = 2;
    public VehicleAI[] Enemies;
    public VehicleWaypoint FirstWaypoint;
    public int Counter = 3;

    List<VehicleWaypoint> waypoints;
    IPlayer racingPlayer;
    int playerNextWaypoint;

    float counterTimer;

    [Inject] IInputManager inputManager = default;
    [Inject] INotificationManager notificationManager = default;
    [Inject] ISceneState sceneState = default;

    public void Start()
    {
        foreach (var enemy in Enemies) {
            enemy.Race = this;
            enemy.enabled = false;
        }

        waypoints = new List<VehicleWaypoint>();
        VehicleWaypoint wp = FirstWaypoint;
        do {
            waypoints.Add(wp);
            wp = wp.Next;
        } while (wp != FirstWaypoint);
    }

    public VehicleWaypoint FindClosestWaypoint(Vector3 target)
    {
        float closestDistance = float.MaxValue;
        int closestWaypoint = -1;

        for (int i = 0; i < waypoints.Count; i++) {
            float distance = Vector3.Distance(waypoints[i].transform.position, target);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestWaypoint = i;
            }
        }

        return waypoints[closestWaypoint];
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Observe(sceneState.OnUpdate);
    }

    public void OnPlayerEnterTrigger(IPlayer player)
    {
        if (racingPlayer == null) {
            //player.Vehicle.CurrentVehicle.FullStop();
            player.Vehicle.CurrentVehicle.Position = Trigger.transform.position;
            player.Vehicle.CurrentVehicle.Rotation = Trigger.transform.rotation;

            playerNextWaypoint = waypoints.IndexOf(FirstWaypoint);
            Trigger.transform.position = FirstWaypoint.transform.position;

            inputManager.OverrideInputForPlayer(player.Index, DummyInputSource.Instance);

            racingPlayer = player;
            counterTimer = 0.0f;
            UpdateCounterTimer(0.0f);

            return;
        }

        if (racingPlayer != player)
            return;

        playerNextWaypoint = (playerNextWaypoint + 1) % waypoints.Count;
        Trigger.transform.position = waypoints[playerNextWaypoint].transform.position;

        if (waypoints[playerNextWaypoint] == FirstWaypoint) {
            --Laps;
            if (Laps > 0)
                notificationManager.DisplayMessage($"{Laps} lap(s) left..."); // FIXME: localization
            else {
                racingPlayer = null;
                foreach (var enemy in Enemies)
                    enemy.gameObject.SetActive(false);
                Trigger.gameObject.SetActive(false);
                notificationManager.DisplayMessage("Race Complete!"); // FIXME: localization
            }
        }
    }



/*
    void IOnUpdate.Do(float deltaTime)
    {
        if (racingPlayer == null)
            return;

        if (counterTimer > 0.0f)
            UpdateCounterTimer(deltaTime);

        // FIXME: âûäåëåíèå ïàìÿòè êàæäûé êàäð - ýòî ïëîõî
        var positions = new List<(float distance, RacePosition positionComponent)>();
        foreach (var enemy in Enemies)
            positions.Add((DeterminePosition(enemy.nextWaypoint, enemy.transform.position), enemy.GetComponent<RacePosition>()));

        var nextWaypoint = waypoints[playerNextWaypoint];
        positions.Add((DeterminePosition(nextWaypoint, racingPlayer.Position), ((Player)racingPlayer).GetComponent<RacePosition>()));

        // Ñîðòèðóåì â îáðàòíîì ïîðÿäêå
        positions.Sort((a, b) => {
                if (a.distance > b.distance)
                    return -1;
                if (a.distance < b.distance)
                    return 1;
                return 0;
            });

        int index = 1;
        foreach (var it in positions)
            it.positionComponent.Position = index++;
    }

    float DeterminePosition(VehicleWaypoint nextWaypoint, Vector3 position)
    {
        VehicleWaypoint prevWaypoint;
        int segmentIndex;

        // FIXME: èñïîëüçîâàòü áîëåå ýôôåêòèâíûé ñïîñîá, ÷åì ëèíåéíûé ïîèñê
        int index = waypoints.IndexOf(nextWaypoint);
        if (index < 0)
            return 0.0f;

        if (index == 0) {
            prevWaypoint = waypoints[waypoints.Count - 1];
            segmentIndex = waypoints.Count - 1;
        } else {
            prevWaypoint = waypoints[index - 1];
            segmentIndex = index - 1;
        }

        float step = 1.0f / waypoints.Count;
        float start = (float)segmentIndex * step;
        float end = start + step;

        Vector3 p1 = prevWaypoint.transform.position;
        Vector3 p2 = nextWaypoint.transform.position;
        float delta = MathUtility.FindNearestPointOnLine(p1, p2, position);

        return start + (end - start) * delta; // + lapsCount
    }

    void StartRace()
    {
        notificationManager.DisplayMessage("GO !"); // FIXME: localization

        inputManager.OverrideInputForPlayer(racingPlayer.Index, null);

        foreach (var enemy in Enemies) {
            enemy.enabled = true;
            enemy.StartFromWaypoint(FirstWaypoint);
        }
    }

    void UpdateCounterTimer(float deltaTime)
    {
        counterTimer -= deltaTime;
        if (counterTimer <= 0.0f) {
            if (Counter == 0)
                StartRace();
            else {
                notificationManager.DisplayMessage($"{Counter}");
                Counter--;
                counterTimer = 1.0f;
            }
        }
    }
}
*/


/* Контроллер, который делает все (GOD-Object)
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _aimCam;
    [SerializeField] private StarterAssetsInputs _input;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorController animator1;
    [SerializeField] private AnimatorController animator2;
    [SerializeField] private GameObject Rifle;
    [SerializeField] private GameObject Pistol;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private ThirdPersonController thirdPersonController;
    
    [SerializeField] private Transform onFireObject;
    
    [SerializeField] private float fireSpeed = 0.5f;
    [SerializeField] private float fireAccurate = 0.5f;
    [SerializeField] private GameObject RifleStartBullet;

    private float fireReloading = 0;

    private void Update() 
    {
        var mouseWorldPosition = Vector3.zero;
        var hitPoint = Vector3.zero;
        var screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        var ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        
        Transform hitTransform = null;
        
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask)) 
        {
            mouseWorldPosition = raycastHit.point;
            hitPoint = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        if (_input.isAim) 
        {
            _aimCam.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        } 
        else 
        {
            _aimCam.gameObject.SetActive(false);
            thirdPersonController.SetRotateOnMove(true);
            thirdPersonController.SetSensitivity(normalSensitivity);

            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
        }

        if (_input.isFire)
        {
            if (fireReloading <= 0)
            {
                fireReloading = fireSpeed;

                if (Random.Range(0, 1f) > fireAccurate)
                {
                   var obj = Instantiate(onFireObject, hitPoint, Quaternion.identity);
                    
                    //var obj = Instantiate(bullet, RifleStartBullet, Quaternion.identity);
                    //var bulletObj = obj.GetComponent<Bullet>();
                    //bulletObj.SetEndPos(hitPoint);
                    //bulletObj.StartFly();
                }
                
                hitTransform.GetComponent<Rigidbody>().AddExplosionForce(1000, transform.forward, 100);
            }
        }

        fireReloading -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

    public void SwitchWeapon()
    {
      if (pistol)
        {
            animator.runtimeAnimatorController = animator1;
            Pistol.SetActive(true);
            Rifle.SetActive(false);
        }
    }
}*/