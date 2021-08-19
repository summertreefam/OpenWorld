using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCommand
{
   public class MoveCommand
       : ICommand
   {
        float _walkSpeed = 2f;

        float _horizontal = 0;
        float _vertical = 0;

        public MoveCommand(float horizontal, float vertical)
        {
            _horizontal = horizontal;
            _vertical = vertical;
        }

        void ICommand.Execute(GameObject playerGameObj)
        {
            if(playerGameObj == null)
            {
                return;
            }

            if(playerGameObj.transform == null)
            {
                return;
            }

            Vector3 pos = playerGameObj.transform.position;

            pos.x += _horizontal * Time.deltaTime * _walkSpeed;
            pos.z += _vertical * Time.deltaTime * _walkSpeed;

            playerGameObj.transform.position = pos;
        }
    }
}

