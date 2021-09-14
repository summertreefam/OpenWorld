using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCamera
{
    public abstract class GameCamera
        : BaseCamera
    {
        public Vector3 _offsetPos = Vector3.zero;

        protected Transform _targetTm = null;

        protected override void Start()
        {
            base.Start();
        }

        public virtual GameCamera Create(Transform targetTm)
        {
            if (targetTm == null)
            {
                return null;
            }

            SetParent(this);

            _targetTm = targetTm;

            return this;
        }

        protected abstract void FixedUpdate();
    }
}

