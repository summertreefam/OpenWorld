using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCommand;

namespace NHandler
{
    public class PlayerInputHandler
    {
        public ICommand<NCreature.Player> HandleInput()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                return new PlayerJumpCommand();
            }

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            if (horizontal != 0 ||
                vertical != 0)
            {
                return new PlayerMoveCommand(horizontal, vertical);
            }

            return null;
        }
    }
}

