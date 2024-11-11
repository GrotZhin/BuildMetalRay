using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class NewBehaviourScript : MonoBehaviour
    {
     public int restaure = 40;
     void OnTriggerEnter(Collider hitInfo){
           PlayerLife playerLife = hitInfo.GetComponent<PlayerLife>();
           if(playerLife != null){
                playerLife.RestaureLife(restaure);
                Destroy(gameObject);
           }
    }
}
}
