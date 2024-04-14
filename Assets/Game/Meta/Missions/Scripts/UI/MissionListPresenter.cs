using System;
using Game.Gameplay.Player;
using GameSystem;
using Windows;
using UnityEngine;

namespace Game.Meta
{
    public sealed class MissionListPresenter : MonoWindow, IGameConstructElement
    {
        [SerializeField]
        private MissionItem[] missionItems;

        private MissionsManager missionsManager;

        protected override void OnShow(object args)
        {
            this.missionsManager.OnMissionChanged += this.OnMissionChanged;

            var missions = this.missionsManager.GetMissions();
            for (int i = 0, count = missions.Length; i < count; i++)
            {
                var mission = missions[i];
                var presenter = this.GetPresenter(mission.Difficulty);
                presenter.Start(mission);
            }
        }

        protected override void OnHide()
        {
            this.missionsManager.OnMissionChanged -= this.OnMissionChanged;

            for (int i = 0, count = this.missionItems.Length; i < count; i++)
            {
                var presenter = this.missionItems[i].presenter;
                presenter.Stop();
            }
        }
        
        private void OnMissionChanged(Mission mission)
        {
            var presenter = this.GetPresenter(mission.Difficulty);
            if (presenter.IsShown)
            {
                presenter.Stop();
            }

            presenter.Start(mission);
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.missionsManager = context.GetService<MissionsManager>();
            var moneyPanelAnimator = context.GetService<MoneyPanelAnimator_AddMoney>();

            for (int i = 0, count = this.missionItems.Length; i < count; i++)
            {
                var missionItem = this.missionItems[i];
                missionItem.presenter.Construct(this.missionsManager, moneyPanelAnimator);
            }
        }

        private MissionPresenter GetPresenter(MissionDifficulty difficulty)
        {
            for (int i = 0, count = this.missionItems.Length; i < count; i++)
            {
                var missionItem = this.missionItems[i];
                if (missionItem.difficulty == difficulty)
                {
                    return missionItem.presenter;
                }
            }

            throw new Exception($"Mission with difficulty {difficulty} is not found"!);
        }

        [Serializable]
        private sealed class MissionItem
        {
            [SerializeField]
            public MissionDifficulty difficulty;

            [SerializeField]
            public MissionPresenter presenter;
        }
    }
}