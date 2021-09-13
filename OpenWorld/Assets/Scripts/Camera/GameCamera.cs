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
        protected Transform _cameraRootTm { get; private set; }

        protected virtual bool Init(Transform targetTm)
        {
            if(targetTm == null)
            {
                return false;
            }

            _cameraRootTm = new GameObject("PlayerCameraRoot").transform;

            _camera = gameObject.AddComponent<Camera>();

            gameObject.transform.SetParent(_cameraRootTm);

            _targetTm = targetTm;

            return true;
        }

        public abstract GameCamera Create(Transform targetTm);
        protected abstract void FixedUpdate();
    }
}

