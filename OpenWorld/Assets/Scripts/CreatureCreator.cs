using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;

namespace NCreator
{
    public class CreatureCreator
        : MonoBehaviour
    {
        private void Start()
        {
            CreatePlayer();
        }

        void CreatePlayer()
        {
            //var playerGameObj = Instantiate(Resources.Load("Prefabs/Crafter")) as GameObject;

            var playerGameObj = Instantiate(Resources.Load("Prefabs/BasicMotionsDummy")) as GameObject;
            if (playerGameObj == null)
            {
                return;
            }

            AddPlayerFollowCamera(playerGameObj.AddComponent<Player>());

            playerGameObj.transform.position = Vector3.zero;
        }

        void AddPlayerFollowCamera(Player player)
        {
            if(player == null ||
               player.transform == null)
            {
                return;
            }

            var followCameraGameObj = new GameObject("FollowCamera");
            if (followCameraGameObj == null)
            {
                return;
            }

            followCameraGameObj.tag = "MainCamera";
            followCameraGameObj.transform.SetParent(transform.parent);

            var playerFollowCamera = followCameraGameObj.AddComponent<PlayerFollowCamera>();
            if (playerFollowCamera == null)
            {
                return;
            }

            followCameraGameObj.AddComponent<Camera>();

            playerFollowCamera.Create(player);
        }
    }
}

