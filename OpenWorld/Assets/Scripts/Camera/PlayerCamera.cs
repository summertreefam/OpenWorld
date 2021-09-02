using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCamera
{
    public class PlayerCamera
        : GameCamera
    {
        public override GameCamera Create(Transform targetTm)
        {
            if(!Init(targetTm))
            {
                return null;
            }

            return this;
        }

        protected override bool Init(Transform targetTm)
        {
            if(!base.Init(targetTm))
            {
                return false;
            }

            _offsetPos = new Vector3(0, 1.5f, -4f);

            return true;
        }

        protected override void FixedUpdate()
        {
            FollowPlayer();
        }

        void FollowPlayer()
        {
            if(!_targetTm)
            {
                return;
            }

            transform.position = _targetTm.position + _offsetPos;
        }
    }
}
