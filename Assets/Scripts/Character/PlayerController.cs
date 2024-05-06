using Bullets;
using Component;
using Component.HitPoints;
using Component.Move;
using Component.Shooting;
using Core;
using Interface;
using VContainer;

namespace Character
{
    public class PlayerController : IPauseListener, IResumeListener, IStartListener, IFinishListener
    {
        private readonly HitPointsController _hitPointsController;
        private readonly MoveController _moveController;
        private readonly ShootingController _shootingController;
        private readonly InputHandler _inputHandler;
        private readonly GameManager _gameManager;

        public PlayerController(
            HitPointsComponent hitPointsComponent, 
            MoveComponent moveComponent, 
            ShootingComponent shootingComponent, 
            InputHandler inputHandler, 
            GameManager gameManager,
            BulletsController bulletsController)
        {
            _inputHandler = inputHandler;
            _gameManager = gameManager;
            
            shootingComponent.Construct(bulletsController);
            hitPointsComponent.Construct(gameManager);
            moveComponent.Construct();
            
            _shootingController = shootingComponent.GetController();
            _hitPointsController = hitPointsComponent.GetController();
            _moveController = moveComponent.GetController();
            
            _gameManager.AddFinishListener(this);
            _gameManager.AddResumeListener(this);
            _gameManager.AddPauseListener(this);
            _gameManager.AddStartListener(this);
        }

        ~PlayerController()
        {
            _gameManager.RemoveFinishListener(this);
            _gameManager.RemoveResumeListener(this);
            _gameManager.RemovePauseListener(this);
            _gameManager.RemoveStartListener(this);
        }

        public void OnStart()
        {
            OnResume();
        }

        public void OnFinish()
        {
            OnPause();
        }
        
        public void OnResume()
        {
            _inputHandler.DirectionButtonPressed += _moveController.Move;
            _inputHandler.ShootingButtonPressed += _shootingController.Shoot;
            _hitPointsController.HitPointsGone += _gameManager.FinishGame;
        }

        public void OnPause()
        {
            _inputHandler.DirectionButtonPressed -= _moveController.Move;
            _inputHandler.ShootingButtonPressed -= _shootingController.Shoot;
            _hitPointsController.HitPointsGone -= _gameManager.FinishGame;
        }

        public void TakeDamage(int damage)
        {
            _hitPointsController.TakeDamage(damage);
        }
    }
}