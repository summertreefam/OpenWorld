using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCamera
{
    public class UICamera
        : BaseCamera
    {
        protected override void Start()
        {
            base.Start();

            SetParent(this);
        }
    }
}

