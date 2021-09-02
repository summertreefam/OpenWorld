using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;

namespace NCommand
{
   public class MoveCommand
       : ICommand
   {
        float _walkSpeed = 1.5f;
        float _runSpeed = 2f;

        float _horizontal = 0;
        float _vertical = 0;

        public MoveCommand(float horizontal, float vertical)
        {
            _horizontal = horizontal;
            _vertical = vertical;
        }

        void ICommand.Execute(Creature creature)
        {
            if (creature == null ||
                creature.Rigidbody == null)
            {
                return;
            }

            var inputAxis = new Vector3(_horizontal, 0, _vertical);
            Vector3 creaturePos = creature.Position;

            creaturePos.x += inputAxis.x * Time.fixedDeltaTime * _walkSpeed;
            creaturePos.z += inputAxis.z * Time.fixedDeltaTime * _walkSpeed;

            creature.Rigidbody.MovePosition(creaturePos);

            var rot = Quaternion.LookRotation(inputAxis);

            creature.Rigidbody.MoveRotation(Quaternion.Lerp(creature.Rigidbody.rotation, rot, Time.fixedDeltaTime * _walkSpeed * 2f));
        }
    }
}

