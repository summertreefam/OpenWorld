using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;

namespace NCommand
{
    public interface ICommand
    {
        void Execute(Creature creature);
    }
}

