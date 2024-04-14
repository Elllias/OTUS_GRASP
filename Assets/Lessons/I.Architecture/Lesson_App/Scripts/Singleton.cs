using System;
using Entities;
using Lessons.Architecture.Components;
using Lessons.Architecture.GameSystem;
using UnityEngine;

// ReSharper disable UnusedType.Global

namespace Lessons.Architecture.AppArchitecture
{
    // public sealed class JoystickInput
    // {
    //     public static JoystickInput Instance;
    //
    //     public event Action<Vector3> OnMove;
    // }
    //
    // public interface IMoveInput
    // {
    //     event Action<Vector3> OnMove;
    // }
    //
    // public sealed class CharacterService
    // {
    //     public static CharacterService Instance;
    //
    //     public IEntity Character
    //     {
    //         get { return this.character; }
    //     }
    //
    //     [SerializeField]
    //     private Entity character;
    // }
    //
    // public sealed class KeyboardInput
    // {
    //     public static KeyboardInput Instance;
    //
    //     public event Action<Vector3> OnMove;
    // }
    //
    // public static class GameSettings
    // {
    //     public static bool IsJoystick;
    // }
    //
    // public interface ICharacterService
    // {
    //     IEntity Character { get; }
    // }

    //Проблема №1 нельзя подменять реализацию:
    
    
    
    // public sealed class MoveController : IStartGameListener, IFinishGameListener
    // {
    //     void IStartGameListener.OnStartGame()
    //     {
    //         JoystickInput.Instance.OnMove += this.OnMove;
    //     }
    //
    //     void IFinishGameListener.OnFinishGame()
    //     {
    //         JoystickInput.Instance.OnMove -= this.OnMove;
    //     }
    //
    //     private void OnMove(Vector3 direction)
    //     {
    //         CharacterService.Instance.Character.Get<IMoveComponent>().Move(direction);
    //     }
    // }
    
    
    //Проблема 2: Скрытые зависимости в середине кода...
    // public sealed class MoveController : IStartGameListener, IFinishGameListener
    // {
    //     void IStartGameListener.OnStartGame()
    //     {
    //         JoystickInput.Instance.OnMove += this.OnMove;
    //     }
    //
    //     void IFinishGameListener.OnFinishGame()
    //     {
    //         JoystickInput.Instance.OnMove -= this.OnMove;
    //     }
    //
    //     private void OnMove(Vector3 direction)
    //     {
    //         //Вызовется в середине кода...
    //         CharacterService.Instance.Character.Get<MoveComponent>().Move(direction);
    //     }
    // }
    //
    //
    //
    //
    //
    //
    // //Проблема №1 нельзя подменять реализацию:
    // public sealed class MoveController : MonoBehaviour, IStartGameListener, IFinishGameListener
    // {
    //     void IStartGameListener.OnStartGame()
    //     {
    //         if (GameSettings.IsJoystick)
    //             JoystickInput.Instance.OnMove += this.OnMove;
    //         else
    //             KeyboardInput.Instance.OnMove += this.OnMove;
    //     }
    //
    //     void IFinishGameListener.OnFinishGame()
    //     {
    //         if (GameSettings.IsJoystick)
    //             JoystickInput.Instance.OnMove -= this.OnMove;
    //         else
    //             KeyboardInput.Instance.OnMove -= this.OnMove;
    //     }
    //
    //     private void OnMove(Vector3 direction)
    //     {
    //         CharacterService.Instance.Character.Get<IMoveComponent>().Move(direction);
    //     }
    // }
    
    
    // //Решение:
    // public sealed class MoveController : MonoBehaviour, IStartGameListener, IFinishGameListener
    // {
    //     private IEntity character;
    //
    //     private IMoveInput moveInput;
    //
    //     public void Construct(IMoveInput moveInput, ICharacterService characterService)
    //     {
    //         this.moveInput = moveInput;
    //         this.character = characterService.Character;
    //     }
    //
    //     void IStartGameListener.OnStartGame()
    //     {
    //         this.moveInput.OnMove += this.OnMove;
    //     }
    //
    //     void IFinishGameListener.OnFinishGame()
    //     {
    //         this.moveInput.OnMove -= this.OnMove;
    //     }
    //
    //     private void OnMove(Vector3 direction)
    //     {
    //         this.character.Get<IMoveComponent>().Move(direction);
    //     }
    // }

    
    
    // //Проблема 3: Высокая зависимость от проекта, нельзя перенести в другой проект
    // public sealed class MoveController : IStartGameListener, IFinishGameListener
    // {
    //     void IStartGameListener.OnStartGame()
    //     {
    //         JoystickInput.Instance.OnMove += this.OnMove;
    //     }
    //
    //     void IFinishGameListener.OnFinishGame()
    //     {
    //         JoystickInput.Instance.OnMove -= this.OnMove;
    //     }
    //
    //     private void OnMove(Vector3 direction)
    //     {
    //         //Вызовется в середине кода...
    //         CharacterService.Instance.Character.Get<MoveComponent>().Move(direction);
    //     }
    // }

    
    
}