using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    public sealed class ConveyorsService
    {
        [ReadOnly, ShowInInspector]
        private IEntity[] conveyors;

        public IEntity FindConveyor(string id)
        {
            for (int i = 0, count = this.conveyors.Length; i < count; i++)
            {
                var conveyour = this.conveyors[i];
                var conveyourId = conveyour.Get<IComponent_GetId>().Id;
                if (conveyourId == id)
                {
                    return conveyour;
                }
            }

            throw new Exception($"Conveyor with {id} is not found!");
        }

        public IEntity[] GetAllConveyors()
        {
            return this.conveyors;
        }

        public void SetupConveyours(IEnumerable<IEntity> conveyors)
        {
            this.conveyors = conveyors.ToArray();
        }
    }
}