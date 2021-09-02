using UnityEngine;
using System.Collections;

namespace NCamera
{
    public enum ViewType
    {
        FP, // 1인칭
        TP, // 3인칭
    }

    public class CameraFactory
    {
        public GameCamera CreatePlayerCamera(ViewType viewType, Transform targetTm)
        {
            var cameraGameObj = new GameObject("PlayerCamera");
            GameCamera gameCamera = null;

            switch (viewType)
            {
                case ViewType.FP:
                    gameCamera = cameraGameObj.AddComponent<PlayerFollowCamera>();
                    break;

                case ViewType.TP:
                default:
                    gameCamera = cameraGameObj.AddComponent<PlayerCamera>();
                    break;
            }

            gameCamera.Create(targetTm);

            return gameCamera;
        }
    }
}

