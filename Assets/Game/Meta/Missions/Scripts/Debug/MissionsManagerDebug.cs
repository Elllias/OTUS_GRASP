#if UNITY_EDITOR
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta
{
    public sealed class MissionsManagerDebug : MonoBehaviour
    {
        [SerializeField]
        private MissionsManager manager;

        [PropertySpace(8)]
        [Button]
        private void ReceiveReward(MissionDifficulty difficulty)
        {
            var mission = this.manager.GetMission(difficulty);
            if (this.manager.CanReceiveReward(mission))
            {
                this.manager.ReceiveReward(mission);
                Debug.Log($"RECEIVED REWARD {mission.MoneyReward} FROM MISSION {mission.Id}");
            }
        }

        private void Reset()
        {
            this.manager = this.GetComponent<MissionsManager>();
        }
    }
}
#endif