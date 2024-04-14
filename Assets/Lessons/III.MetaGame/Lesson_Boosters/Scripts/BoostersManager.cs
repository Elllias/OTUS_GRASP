using System;
using System.Collections;
using System.Collections.Generic;
using Game.Gameplay.Player;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame.Lesson_Boosters
{
    public sealed class BoostersManager : MonoBehaviour, IGameStartElement
    {
        public event Action<Booster> OnBoosterLaunched;

        public event Action<Booster> OnBoosterStarted;

        public event Action<Booster> OnBoosterFinished;
        
        private BoosterFactory factory;

        // private MoneyStorage moneyStorage;
        
        [PropertySpace(8), ReadOnly, ShowInInspector]
        private readonly List<Booster> currentBoosters = new();

        [GameInject]
        public void Construct(BoosterFactory factory)
        {
            this.factory = factory;
        }

        [Title("Methods")]
        [Button]
        [GUIColor(0, 1, 0)]
        public void LaunchBooster(BoosterConfig config)
        {
            // var moneyPrice = config.moneyPrice;
            // if (this.moneyStorage.Money < moneyPrice)
            // {
            //     return;
            // }
            //
            // this.moneyStorage.SpendMoney(moneyPrice);

            var booster = this.factory.CreateBooster(config);
            booster.OnCompleted += this.OnEndBooster;

            this.currentBoosters.Add(booster);

            booster.Start();
            this.OnBoosterStarted?.Invoke(booster);
            this.OnBoosterLaunched?.Invoke(booster);
        }

        public Booster[] GetActiveBoosters()
        {
            return this.currentBoosters.ToArray();
        }

        void IGameStartElement.StartGame()
        {
            this.StartAllBoosters();
        }

        private void StartAllBoosters()
        {
            for (int i = 0, count = this.currentBoosters.Count; i < count; i++)
            {
                var booster = this.currentBoosters[i];
                if (booster.IsActive)
                {
                    continue;
                }

                booster.Start();
                this.OnBoosterStarted?.Invoke(booster);
            }
        }

        private void OnEndBooster(Booster booster)
        {
            booster.OnCompleted -= this.OnEndBooster;
            this.StartCoroutine(this.EndBoosterInNextFrame(booster));
        }

        private IEnumerator EndBoosterInNextFrame(Booster booster)
        {
            yield return new WaitForEndOfFrame();
            this.currentBoosters.Remove(booster);
            this.OnBoosterFinished?.Invoke(booster);
        }
    }
}