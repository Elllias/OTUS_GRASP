using System.Collections.Generic;
using UnityEngine;

namespace GameNodes
{
    public sealed class PlayerContext : GameNode
    {
        [Space(12)]
        [SerializeField]
        public HeroService heroService = new();

        [SerializeField]
        private MoveInput moveInput;
        
        protected override IEnumerable<object> LoadServices()
        {
            yield return this.heroService;
            yield return this.moveInput;
            yield return new MoveController();
        }
    }
}