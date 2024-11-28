using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class playAnimation : MonoBehaviour
    {
        public Animator animator;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Animationidle()
        {
        animator.Play("guitar ship_idleani");
        }
    }
}
