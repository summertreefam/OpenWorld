using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;

namespace NCommand
{
    public class PlayerJumpCommand
        : ICreatureActionCommand<Player>
    {
        float _jumpPower = 2f;

        void ICreatureActionCommand<Player>.Execute(Player player)
        {
            if (player == null)
            {
                return;
            }

            //player.Rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }

        NType.NCreature.NAction.ECreatureMove ICreatureActionCommand<Player>.ECreatureMove
        {
            get
            {
                return NType.NCreature.NAction.ECreatureMove.Jump;
            }
        }
    }
}
