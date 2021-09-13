using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NHandler;

namespace NCreature
{
    public class Player
        : Character
    {
        public NCamera.GameCamera PlayerGameCamera { get; private set; }

        PlayerInputHandler _playerInputHandler = null;
        
        protected override void Start()
        {
            base.Start();

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

            command.Execute(this);
        }

        public void SetPlayerCamera(NCamera.GameCamera camera)
        {
            PlayerGameCamera = camera;
        }
    }
}

