using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Create ChestsConfig", fileName = "ChestsConfig", order = 0)]
    public class ChestsConfig : ScriptableObject
    {
        public List<ChestData> ChestsTimeData;
    }
}