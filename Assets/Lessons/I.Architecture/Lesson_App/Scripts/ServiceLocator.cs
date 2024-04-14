// using System;
// using Entities;
// using Lessons.Architecture.Components;
// using Lessons.Architecture.GameContexts;
// using Services;
// using UnityEngine;
//
// // ReSharper disable UnusedType.Global
//
// namespace Lessons.Architecture.AppArchitecture
// {
//     public interface IMoveInput
//     {
//         event Action<Vector3> OnMove;
//     }
//
//     public sealed class CharacterService
//     {
//         public IEntity Character
//         {
//             get { return this.character; }
//         }
//
//         [SerializeField]
//         private ListEntity character;
//     }
//
//     public interface ICharacterService
//     {
//         IEntity Character { get; }
//     }
//     
//     public interface IConstructListener
//     {
//         void Construct(IServiceLocator context);
//     }
//
//     public interface IServiceLocator
//     {
//         T GetService<T>();
//     }
//
//     // public sealed class MoveController : IStartGameListener, IFinishGameListener
//     // {
//     //     void IStartGameListener.OnStartGame()
//     //     {
//     //         var moveInput = ServiceLocator.GetService<IMoveInput>();
//     //         moveInput.OnMove += this.OnMove;
//     //     }
//     //
//     //     void IFinishGameListener.OnFinishGame()
//     //     {
//     //         var moveInput = ServiceLocator.GetService<IMoveInput>();
//     //         moveInput.OnMove -= this.OnMove;
//     //     }
//     //
//     //     private void OnMove(Vector3 direction)
//     //     {
//     //         var characterService = ServiceLocator.GetService<ICharacterService>();
//     //         var character = characterService.Character;
//     //         character.Get<IMoveComponent>().Move(direction);
//     //     }
//     // }
//     
//     // Проблема 1: Скрытые зависимости в середине кода...
//     // Проблема 2: Жесткая зависимость от Service Locator, нельзя перенести в другой проект
//     public sealed class MoveController : IStartGameListener, IFinishGameListener
//     {
//         void IStartGameListener.OnStartGame()
//         {
//             var moveInput = ServiceLocator.GetService<IMoveInput>();
//             moveInput.OnMove += this.OnMove;
//         }
//     
//         void IFinishGameListener.OnFinishGame()
//         {
//             var moveInput = ServiceLocator.GetService<IMoveInput>();
//             moveInput.OnMove -= this.OnMove;
//         }
//     
//         private void OnMove(Vector3 direction)
//         {
//             var characterService = ServiceLocator.GetService<CharacterService>();
//         }
//     }
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
//     //1. Теперь зависимости видны в методе Construct, но только внутри класса,
//     //поэтому разработчику придется по-любому зайти в класс и посмотреть
//     
//     //2. Нет жесткой зависимости на статический ServiceLocator,
//     //есть зависимость только от интерфейса, который сами можем реализовать
//     
//     //3. Move Controller имеет второстепенную зависимость — получение ссылок из ServiceLocator
//     //a.) Это дополнительное чтение кода, которое не относится к тому, что делает класс
//     //b.) Такая конструкция хуже переносится в другой проект,
//     // потому что нужно переделать метод Construct с явными аргументами
//     
//     //4. Неудобно тестировать, так как нужно сетапить ServiceLocator
//     
//     
//     
//     // public sealed class MoveController : IConstructListener, IStartGameListener, IFinishGameListener
//     // {
//     //     private IMoveInput moveInput;
//     //
//     //     private ICharacterService characterService;
//     //
//     //     void IConstructListener.Construct(IServiceLocator context)
//     //     {
//     //         this.moveInput = context.GetService<IMoveInput>();
//     //         this.characterService = context.GetService<ICharacterService>(); 
//     //     }
//     //
//     //     void IStartGameListener.OnStartGame()
//     //     {
//     //         this.moveInput.OnMove += this.OnMove;
//     //     }
//     //
//     //     void IFinishGameListener.OnFinishGame()
//     //     {
//     //         this.moveInput.OnMove -= this.OnMove;
//     //     }
//     //
//     //     private void OnMove(Vector3 direction)
//     //     {
//     //         this.characterService.Character.Get<IMoveComponent>().Move(direction);
//     //     }
//     // }
//     
//     
// }