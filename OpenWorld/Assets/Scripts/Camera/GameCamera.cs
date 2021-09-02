using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCamera
{
    public abstract class GameCamera
        : MonoBehaviour
    {
        public Vector3 _offsetPos = Vector3.zero;

        protected Camera _camera = null;
        protected Transform _targetTm = null;

        protected virtual bool Init(Transform targetTm)
        {
            if(targetTm == null)
            {
                return false;
            }

            _camera = gameObject.AddComponent<Camera>();

            gameObject.transform.SetParent(targetTm.parent);

            _targetTm = targetTm;

            return true;
        }

        public abstract GameCamera Create(Transform targetTm);
        protected abstract void FixedUpdate();
    }
}

