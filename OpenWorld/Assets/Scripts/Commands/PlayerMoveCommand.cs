using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCommand
{
    public class PlayerMoveCommand
        : ICommand<NCreature.Player>
    {
        float _walkSpeed = 2f;
        float _runSpeed = 2f;

        float _horizontal = 0;
        float _vertical = 0;

        Vector3 _moveDir = Vector3.zero;

        public PlayerMoveCommand(float horizontal, float vertical)
        {
            _horizontal = horizontal;
            _vertical = vertical;
        }

        void ICommand<NCreature.Player>.Execute(NCreature.Player player)
        {
            if (player == null ||
                player.PlayerGameCamera == null)
            {
                return;
            }

            var playerCamera = player.PlayerGameCamera;

            Vector3 cameraForwardDir = Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 move = _vertical * cameraForwardDir + _horizontal * playerCamera.transform.right;

            if (move.magnitude > 1f)
            {
                move.Normalize();
            }

            move = player.transform.InverseTransformDirection(move);

            float turnAmount = Mathf.Atan2(move.x, move.z);

            player.transform.Rotate(0, turnAmount * 280f * Time.deltaTime, 0);

            player.Animator.SetBool("IsWalk", move.magnitude > 0);

            _moveDir = player.transform.forward * move.magnitude;
            _moveDir *= _walkSpeed;

            player.transform.position += _moveDir * Time.deltaTime;
        }
    }
}

