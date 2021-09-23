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

            var actionCmd = _playerInputHandler.HandleInput(out _eCreatureMove);
            if(actionCmd != null)
            {
                actionCmd.Execute(this);
            }

            UpdateAnim();
        }

        void UpdateAnim()
        {
            if (!_animator)
            {
                return;
            }

            _animator.SetBool("IsWalk", _eCreatureMove != NType.NCreature.NAction.ECreatureMove.Idle);
        }

        public void SetPlayerCamera(NCamera.GameCamera camera)
        {
            PlayerGameCamera = camera;
        }
    }
}

