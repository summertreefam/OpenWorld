using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCreature
{
    public abstract class Creature
        : MonoBehaviour
    {
        public NInfo.CreatureInfo CreatureInfo { get; private set; }

        private void Update()
        {
            ChainUpdate();
        }

        protected abstract void Start();
        protected abstract void ChainUpdate();
    }
}

