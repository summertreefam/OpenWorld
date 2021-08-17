using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAction.NMove
{
    public class Walk
    {
        public struct WalkInfo
        {
            public float Speed;
        }

        WalkInfo? _walkInfo = null;

        public Walk(WalkInfo info)
        {
            _walkInfo = info;
        }
    }
}

