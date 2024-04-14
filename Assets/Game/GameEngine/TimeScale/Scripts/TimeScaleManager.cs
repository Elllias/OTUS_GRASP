using UnityEngine;

namespace Game.GameEngine
{
    public static class TimeScaleManager
    {
        public static float Scale
        {
            get { return Time.timeScale; }
        }

        public static void SetScale(float scale)
        {
            Time.timeScale = scale;
        }
    }
}