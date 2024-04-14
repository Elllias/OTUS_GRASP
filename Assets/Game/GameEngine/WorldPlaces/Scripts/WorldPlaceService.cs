using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class WorldPlaceService : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private WorldPlaceObject[] worldPlaces;

        public void Setup(WorldPlaceObject[] worldPlaces)
        {
            this.worldPlaces = worldPlaces;
        }

        public WorldPlaceObject GetPlace(WorldPlaceType type)
        {
            foreach (var place in this.worldPlaces)
            {
                if (place.Type == type)
                {
                    return place;
                }
            }

            throw new Exception("World place is not found!");
        }

        public bool IsPlaceExists(WorldPlaceType type)
        {
            foreach (var place in this.worldPlaces)
            {
                if (place.Type == type)
                {
                    return true;
                }
            }

            return false;
        }
    }
}