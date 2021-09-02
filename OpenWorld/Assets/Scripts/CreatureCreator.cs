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

            var playerGameObj = Instantiate(Resources.Load("Prefabs/BasicMotionsDummy")) as GameObject;
            if (playerGameObj == null)
            {
                return;
            }

            var playerRoot = new GameObject("PlayerRoot");

            playerGameObj.transform.SetParent(playerRoot.transform);
            playerGameObj.transform.position = Vector3.zero;

            playerGameObj.AddComponent<Player>();

            AddPlayerCamera(playerGameObj);
        }

        void AddPlayerCamera(GameObject playerGameObj)
        {
            if(!playerGameObj)
            {
                return;
            }

            var cameraFactory = new CameraFactory();
            if (cameraFactory == null)
            {
                return;
            }

            cameraFactory.CreatePlayerCamera(ViewType.TP, playerGameObj.transform);
        }
    }
}

