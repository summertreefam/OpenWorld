using UnityEngine;
using System.Collections;

public class FollowCamera
    : MonoBehaviour
{
    public bool IsSmooth;

    protected Vector3 _offsetPos = Vector3.zero;
    protected Vector3 _offsetRot = Vector3.zero;
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

        var targetPos = _targetTm.position + _offsetPos;
        var targetRot = _targetTm.rotation;

        if (IsSmooth)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 2f);

            return;
        }

        transform.position = targetPos;
        transform.rotation = targetRot;
    }
}
