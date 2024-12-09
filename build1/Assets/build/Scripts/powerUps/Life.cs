using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MetalRay
{
    public class NewBehaviourScript : MonoBehaviour
    {
    public ParticleSystem vfx;
     public ParticleSystem vfx2;
     public int restaure = 40;
     void OnTriggerEnter(Collider hitInfo){
           PlayerLife playerLife = hitInfo.GetComponent<PlayerLife>();
           if(playerLife != null){
                playerLife.RestaureLife(restaure);
                soundManager.PlaySound(SoundType.HEAL);
                Destroy(gameObject);
                Instantiate(vfx, transform.position, Quaternion.identity);
                Instantiate(vfx2, transform.position, Quaternion.identity);
           }
    }
}
}