using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NHandler;

namespace NCreature
{
    public class Player
        : Character
    {
        Transform _playerTm = null;

        PlayerInputHandler _playerInputHandler = null;

        protected override void Start()
        {
            _playerTm = transform;

            AddPlayerFollowCamera();

            InitPlayerInputHandler();
        }

        protected override void ChainUpdate()
        {
            ExecuteCommand();
        }

        void InitPlayerInputHandler()
        {
            _playerInputHandler = new PlayerInputHandler();
        }

        void ExecuteCommand()
        {
            if (_playerInputHandler == null)
            {
                return;
            }

            var command = _playerInputHandler.HandleInput();
            if (command == null)
            {
                return;
            }

            command.Execute(gameObject);
        }

        void AddPlayerFollowCamera()
        { 
            var followCameraGameObj = new GameObject("FollowCamera");
            if(followCameraGameObj == null)
            {
                return;
            }

            followCameraGameObj.transform.SetParent(transform);

            var playerFollowCamera = followCameraGameObj.AddComponent<PlayerFollowCamera>();
            if (playerFollowCamera == null)
            {
                return;
            }

            playerFollowCamera.Create(followCameraGameObj);
        }
    }
}

