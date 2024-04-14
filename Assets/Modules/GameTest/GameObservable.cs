using System;
using System.Collections.Generic;

namespace Modules.GameTest
{
    //
    //
    // public sealed class GameObservable
    // {
    //     private readonly List<IGameObserver> observers = new();
    //
    //     public void AddObserver(IGameObserver observer)
    //     {
    //         this.observers.Add(observer);
    //     }
    //
    //     public void RemoveObserver(IGameObserver observer)
    //     {
    //         this.observers.Remove(observer);
    //     }
    //
    //     public void Do<T>() where T : IGameObserver
    //     {
    //         foreach (var observer in this.observers)
    //         {
    //             if (observer is T tObserver)
    //             {
    //                 
    //                 action.Invoke(tObserver);
    //             }
    //         }
    //     }
    // }
    
    
    
    
    //
    // public interface IGameObserver
    // {
    // }
    //
    // public interface IGameStarted : IGameObserver
    // {
    //     void Do();
    // }
    //
    // public interface IGamePaused : IGameObserver
    // {
    //     void Do();
    // }
    //
    // public sealed class Test
    // {
    //     public void AAA(GameObservable gameObservable)
    //     {
    //         gameObservable.Do<IGameStarted>(it => it.Do());
    //         gameObservable.Do<IGamePaused>(it => it.Do());
    //     }
    // }
}