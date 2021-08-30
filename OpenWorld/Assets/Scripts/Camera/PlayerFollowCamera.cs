using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera
    : FollowCamera
{
    public void Create(NCreature.Player player)
    {
        if (player == null)
        {
            return;
        }

        if (player.transform == null)
        {
            return;
        }
        
        _targetTm = player.transform;

        _offsetPos = new Vector3(0, 3f, -5f);
    }
}
