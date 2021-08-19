using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCommand
{
    public interface ICommand
    {
        void Execute(GameObject playerGameObj);
    }
}

