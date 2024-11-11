using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class efectsDestroy : MonoBehaviour
    {
        public float time = 0;
    
        void Update()
        {
        Destroy(this.gameObject, time);
        }
    }
}
