using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;

namespace NCommand
{
    public class JumpCommand
        : ICommand
    {
        float _jumpPower = 2f;

        void ICommand.Execute(Creature creature)
        {
            if (creature == null ||
                creature.Rigidbody == null)
            {
                return;
            }

            creature.Rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }
}
