using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;

namespace NCommand
{
    public class PlayerJumpCommand
        : ICommand<Player>
    {
        float _jumpPower = 2f;

        void ICommand<Player>.Execute(Player player)
        {
            if (player == null)
            {
                return;
            }

            //player.Rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }
}
