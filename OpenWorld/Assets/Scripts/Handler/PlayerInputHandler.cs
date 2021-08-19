using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCommand;

namespace NHandler
{
    public class PlayerInputHandler
    {
        MoveCommand _cmdMove = null;
        JumpCommand _cmdJump = null;

        public ICommand HandleInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            if (horizontal != 0 ||
                vertical != 0)
            {
                return new MoveCommand(horizontal, vertical);
            }

            if(Input.GetKey(KeyCode.Space))
            {
                if(_cmdJump == null)
                {
                    _cmdJump = new JumpCommand();
                }

                return _cmdJump;
            }

            return null;
        }
    }
}

