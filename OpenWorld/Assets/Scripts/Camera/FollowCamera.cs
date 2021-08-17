using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera
    : MonoBehaviour
{
    public bool IsSmooth;
    public Vector3 OffsetVec;

    Transform _targetTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        _targetTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if(_targetTransform == null)
        {
            return;
        }

        transform.position = _targetTransform.position + OffsetVec;
    }
}
