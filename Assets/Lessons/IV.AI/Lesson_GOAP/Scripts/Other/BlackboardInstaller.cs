using AI.Blackboards;
using AI.Waypoints;
using Entities;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class BlackboardInstaller : MonoBehaviour
    {
        [SerializeField]
        private UnityBlackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [SerializeField]
        private MonoEntity unit;

        [BlackboardKey]
        [SerializeField]
        private string waypointsKey;

        [SerializeField]
        private WaypointsPath waypoints;

        [BlackboardKey]
        [SerializeField]
        private string healingKey;
        
        [SerializeField]
        private HealingPoint healingPoint;

        [BlackboardKey]
        [SerializeField]
        private string marketKey;

        [SerializeField]
        private MarketPoint marketPoint;
        
        [BlackboardKey]
        [SerializeField]
        private string beerKey;

        [SerializeField]
        private BeerPoint beerPoint;

        [BlackboardKey]
        [SerializeField]
        private string resourceKey;
        
        [SerializeField]
        private MonoEntity resourceObject;

        private void Awake()
        {
            this.blackboard.AddVariable(this.unitKey, this.unit);
            this.blackboard.AddVariable(this.waypointsKey, this.waypoints);
            this.blackboard.AddVariable(this.healingKey, this.healingPoint);
            this.blackboard.AddVariable(this.marketKey, this.marketPoint);
            this.blackboard.AddVariable(this.beerKey, this.beerPoint);
            this.blackboard.AddVariable(this.resourceKey, this.resourceObject);
        }
    }
}