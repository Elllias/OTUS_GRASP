///Неправильное использование:
///
///
    //
    // public interface IGameListener {
    //     
    //     void OnStartGame();
    //     void OnPauseGame();
    //     void OnResumeGame();
    //     void OnFinishGame();
    // }
    //
    // public sealed class MoveController : IGameListener {
    //     
    //     private Player player;
    //     private MoveInput moveInput;
    //     
    //     public MoveController(Player player, MoveInput moveInput) {
    //         this.player = player;
    //         this.moveInput = moveInput;
    //     }
    //     
    //     public void OnStartGame() => this.moveInput.OnMove += this.OnMove;
    //     public void OnFinishGame() => this.moveInput.OnMove -= this.OnMove;
    //     private void OnMove(Vector3 direction) => this.player.Move(direction);
    //
    //     public void OnPauseGame() {} //Not used...
    //     public void OnResumeGame() {}  //Not used...
    // }

///Правильное использование:
    //
    //
    // public interface IStartGameListener {
    //     void OnStartGame();
    // }
    //
    // public interface IPauseGameListener {
    //     void OnPauseGame();
    // }
    //
    // public interface IResumeGameListener {
    //     void OnResumeGame();
    // }
    //
    // public interface IFinishGameListener {
    //     void OnFinishGame();
    // }
    //


//
    // public sealed class MoveController : 
    //     IStartGameListener,
    //     IFinishGameListener {
    //     
    //     private Player player;
    //     private MoveInput moveInput;
    //     
    //     public MoveController(Player player, MoveInput moveInput) {
    //         this.player = player;
    //         this.moveInput = moveInput;
    //     }
    //     
    //     public void OnStartGame() {
    //         this.moveInput.OnMove += this.OnMove;
    //     }
    //
    //     public void OnFinishGame() {
    //         this.moveInput.OnMove -= this.OnMove;
    //     }
    //
    //     private void OnMove(Vector3 direction) {
    //         this.player.Move(direction);
    //     }
    // }
    
    
    