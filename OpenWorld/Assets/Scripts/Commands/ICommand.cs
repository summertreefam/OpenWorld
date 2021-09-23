using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;

namespace NCommand
{
    public interface ICommand
    {
        void Execute();
    }

    public interface ICreatureActionCommand<T>
        where T : Creature
    {
        void Execute(T t);
        NType.NCreature.NAction.ECreatureMove ECreatureMove { get; }
    }
}

