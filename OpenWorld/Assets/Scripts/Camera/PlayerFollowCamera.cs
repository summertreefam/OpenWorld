using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera
    : FollowCamera
{
    public void Create(GameObject targetGameObj)
    {
        if (targetGameObj == null)
        {
            return;
        }

        targetGameObj.AddComponent<Camera>();

        _targetTm = targetGameObj.transform.parent;
        _offsetPos = new Vector3(0, 1f, -3f);
    }
}
