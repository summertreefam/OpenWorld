using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;
using NCamera;

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
            //var playerGameObj = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
            var playerGameObj = Instantiate(Resources.Load("Prefabs/BasicMotionsDummy")) as GameObject;
            if (playerGameObj == null)
            {
                return;
            }

            var playerRoot = new GameObject("PlayerRoot");

            playerGameObj.transform.SetParent(playerRoot.transform);
            playerGameObj.transform.position = Vector3.zero;

            var player = playerGameObj.AddComponent<Player>();
            if(player == null)
            {
                return;
            }

            player.SetPlayerCamera(AddPlayerCamera(playerGameObj));
        }

        GameCamera AddPlayerCamera(GameObject playerGameObj)
        {
            if(!playerGameObj)
            {
                return null;
            }

            var cameraFactory = new CameraFactory();
            if (cameraFactory == null)
            {
                return null;
            }

            return cameraFactory.CreatePlayerCamera(ViewType.TP, playerGameObj.transform);
        }
    }
}

