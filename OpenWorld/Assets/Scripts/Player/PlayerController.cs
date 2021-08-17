using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NController;
using NAction.NMove;

namespace NPlayer
{
    public class PlayerController
        : MonoBehaviour
    {
        Transform _playerTm = null;

        IController _moveCtr = null;

        // Start is called before the first frame update
        void Start()
        {
            _playerTm = transform;

            InitMoveController();
        }

        // Update is called once per frame
        void Update()
        {
            if (_moveCtr != null)
            {
                _moveCtr.ChainUpdate();
            }
        }
            

        void InitMoveController()
        {
            var walkInfo = new Walk.WalkInfo()
            {
                Speed = 1f,
            };

            _moveCtr = new MoveController()
                .InitWalk(walkInfo);
        }
    }
}

