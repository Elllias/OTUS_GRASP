using Game.GameEngine.GUI;
using GameSystem;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Task «Install GUICamera»",
        menuName = "GameEngine/Construct/New Task «Install GUICamera»"
    )]
    public sealed class ConstructTask_InstallGUICamera : GameContext.ConstructTask
    {
        public override void Construct(GameContext gameContext)
        {
            var worldCameraData = WorldCamera.Instance.GetUniversalAdditionalCameraData();
            var uiCamera = gameContext.GetService<GUICameraService>().Camera;
            worldCameraData.cameraStack.Add(uiCamera);
        }
    }
}