using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCamera
{
    public class PlayerCamera
        : GameCamera
    {
        public float MouseSensitivity = 4f;
        public float Orbit = 10f;
        public float Scroll = 6f;
        public float Distance = 8f;

        Vector3 _rotation = Vector3.zero;

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

            _offsetPos = new Vector3(0, 1.5f, 0);

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

            Rotation();

            _cameraRootTm.position = _targetTm.position + _offsetPos;
        }

        void Zoom()
        {

        }

        void Rotation()

        {
            if (Input.GetAxis("Mouse X") != 0 ||
                Input.GetAxis("Mouse Y") != 0)
            {
                _rotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _rotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;

                if (_rotation.y < 0f)
                {
                    _rotation.y = 0f;
                }
                else if (_rotation.y > 90f)
                {
                    _rotation.y = 90f;
                }
            }

            _cameraRootTm.rotation = Quaternion.Lerp(_cameraRootTm.rotation, Quaternion.Euler(_rotation.y, _rotation.x, 0), Time.deltaTime * Orbit);

            if (transform.localPosition.z != Distance * -1f)
            {
                transform.localPosition = new Vector3(0, 0, Mathf.Lerp(transform.localPosition.z, Distance * -1f, Time.deltaTime * Scroll));
            }
        }
    }
}
