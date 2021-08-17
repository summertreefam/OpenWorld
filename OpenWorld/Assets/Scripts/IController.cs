using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NController
{
    public interface IController
    {
        void Init();
        void ChainUpdate();
    }
}

