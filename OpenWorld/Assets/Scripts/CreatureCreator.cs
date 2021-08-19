using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NCreature;

namespace NCreator
{
    public class CreatureCreator
        : MonoBehaviour
    {
        private void Start()
        {
            CreatePlayer();
        }

        void CreatePlayer()
        {
            var playerGameObj = Instantiate(Resources.Load("Creature/Character")) as GameObject;
            if(playerGameObj == null)
            {
                return;
            }

            playerGameObj.AddComponent<Player>();
            playerGameObj.transform.position = Vector3.zero;
        }
    }
}

