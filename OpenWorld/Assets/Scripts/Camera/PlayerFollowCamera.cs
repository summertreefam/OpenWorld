using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCamera
{
    public class PlayerFollowCamera
        : GameCamera
    {
        public Vector3 _offsetRot = Vector3.zero;
        public Space OffsetPositionSpace = Space.Self;
        public bool LookAt = true;

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
            if (base.Init(targetTm) == false)
            {
                return false;
            }

            _offsetPos = new Vector3(0, 2.5f, -5f);
    
            return true;
        }

        protected override void FixedUpdate()
        {
            Follow();
        }

        void Follow()
        {
            if(!_targetTm)
            {
                return;
            }

            if (OffsetPositionSpace == Space.Self)
            {
                transform.position = _targetTm.TransformPoint(_offsetPos);
            }
            else
            {
                transform.position = _targetTm.position + _offsetPos;
            }

            if (LookAt)
            {
                var direction = _targetTm.position - transform.position;
                direction.y = _offsetRot.y;

                transform.rotation = Quaternion.LookRotation(direction);
            }
            else
            {
                transform.rotation = _targetTm.rotation;
            }
        }
    }
}

