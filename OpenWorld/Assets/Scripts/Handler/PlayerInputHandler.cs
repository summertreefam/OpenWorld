using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCommand;

namespace NHandler
{
    public class PlayerInputHandler
    {
        public ICreatureActionCommand<NCreature.Player> HandleInput(out NType.NCreature.NAction.ECreatureMove eCreatureMove)
        {
            ICreatureActionCommand<NCreature.Player> creatureActionCmd = null; 

            eCreatureMove = NType.NCreature.NAction.ECreatureMove.Idle;

            if (Input.GetKey(KeyCode.Space))
            {
                creatureActionCmd = new PlayerJumpCommand();
            }

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            if (horizontal != 0 ||
                vertical != 0)
            {
                creatureActionCmd = new PlayerMoveCommand(horizontal, vertical); 
            }

            if(creatureActionCmd != null)
            {
                eCreatureMove = creatureActionCmd.ECreatureMove;
            }

            return creatureActionCmd;
        }
    }
}

 