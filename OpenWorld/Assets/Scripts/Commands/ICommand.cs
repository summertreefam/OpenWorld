using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;

namespace NCommand
{
    public interface ICommand<T> where T : Creature
    {
        void Execute(T t);
    }
}

