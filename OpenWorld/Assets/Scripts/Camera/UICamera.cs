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

            Init();
        }

        void Init()
        {
            SetParent(this);

            //_camera.cullingMask =  

            Debug.Log("Screen.width : " + Screen.width);
            Debug.Log("Screen.height : " + Screen.height);
        }
    }
}

