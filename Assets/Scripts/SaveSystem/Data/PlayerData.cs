using System;
using System.Collections.Generic;
using GameEngine.Enums;

namespace SaveSystem.Data
{
    [Serializable]
    public class PlayerData
    {
        public Dictionary<ResourceType, int> Resources;
    }
}