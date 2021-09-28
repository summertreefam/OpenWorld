using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCamera
{
    public class PlayerCamera
        : GameCamera
    {
        readonly System.Tuple<float, float> RotationRange = new System.Tuple<float, float>(0, 90f);

        public float MouseSensitivity = 4f;
        public float Orbit = 10f;
        public float Scroll = 6f;
        public float Distance = 5f;

        Vector3 _rotation = Vector3.zero;

        public override GameCamera Create(Transform targetTm)
        {
            if(!base.Create(targetTm))
            {
                return null;
            }

            _offsetPos = new Vector3(0, 2f, 0);

            return this;
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
            float inputMouseX = Input.GetAxis("Mouse X");
            float inputMouseY = Input.GetAxis("Mouse Y");

            if (inputMouseX != 0 ||
                inputMouseY != 0)
            {
                _rotation.x += inputMouseX * MouseSensitivity;
                _rotation.y += inputMouseY * MouseSensitivity;

                if (_rotation.y < RotationRange.Item1)
                {
                    _rotation.y = RotationRange.Item1;
                }
                else if (_rotation.y > RotationRange.Item2)
                {
                    _rotation.y = RotationRange.Item2;
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
