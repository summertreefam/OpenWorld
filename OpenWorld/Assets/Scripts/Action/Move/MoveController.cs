using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using NController;

namespace NAction.NMove
{
    public enum EMoveType
    {
        None,

        Walk,
    }

    public interface IMove
    {
        void Move(Transform moveTargetTm);
    }

    public class MoveController
        : IController
    {
        Walk _walk = null;

        EMoveType _currMoveType = EMoveType.None;

        void IController.Init()
        {

        }

        void IController.ChainUpdate()
        {

        }

        public MoveController InitWalk(Walk.WalkInfo info)
        {
            _walk = new Walk(info);

            return this;
        }
    }
}


