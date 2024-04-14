using UnityEngine;

namespace Game.GameEngine
{
    public static class CameraUtils
    {
        public static Vector3 FromWorldToUIPosition(Camera worldCamera, Camera uiCamera, Vector3 worldPosition)
        {
            var screenPosition = worldCamera.WorldToScreenPoint(worldPosition);
            return uiCamera.ScreenToWorldPoint(screenPosition);
        }

        public static Vector3 FromUIToWorldPosition(Camera uiCamera, Camera worldCamera, Vector3 uiPosition)
        {
            var screenPosition = uiCamera.WorldToScreenPoint(uiPosition);
            return worldCamera.ScreenToWorldPoint(screenPosition);
        }
    }
}