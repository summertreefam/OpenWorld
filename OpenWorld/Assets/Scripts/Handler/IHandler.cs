using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NHandler
{
    public interface IHandler
    {
        void Init<T>(T t) where T : class;
        void ChainUpdate();
    }
}

