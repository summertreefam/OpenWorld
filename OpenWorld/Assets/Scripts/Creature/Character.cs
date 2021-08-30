using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCreature
{
    public class Character
        : Creature
    {
        public NInfo.CharacterInfo CharacterInfo { get; private set; }

        protected override void Start()
        {
            base.Start();
        }

        protected override void ChainUpdate()
        {
            
        }
    }
}

