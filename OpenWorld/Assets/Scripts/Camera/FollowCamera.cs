using UnityEngine;
using System.Collections;

public class FollowCamera
    : MonoBehaviour
{
    public Vector3 _offsetPos = Vector3.zero;
    public Vector3 _offsetRot = Vector3.zero;
    public Space OffsetPositionSpace = Space.Self;
    public bool LookAt = true;

    protected Transform _targetTm = null;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (_targetTm == null)
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
