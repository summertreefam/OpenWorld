using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCamera
{
    public class BaseCamera
         : MonoBehaviour
    {
        protected Camera _camera = null;
        protected Transform _cameraRootTm = null;

        protected virtual void Start()
        {
            _camera = gameObject.AddComponent<Camera>();
        }

        protected void SetParent(Object obj)
        {
            if(obj == null)
            {
                return;
            }

            _cameraRootTm = new GameObject(obj.name + "Root").transform;

            gameObject.transform.SetParent(_cameraRootTm);
        }
    }
}
