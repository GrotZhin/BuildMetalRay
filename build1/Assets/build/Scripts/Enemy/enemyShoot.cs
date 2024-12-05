using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class enemyShoot : MonoBehaviour
    {
        [SerializeField]public static float speed = 3f;
        public Rigidbody rb;
        public int damage;
        float time = 0f;

        
        

      
        void Start(){
            rb.velocity = (-1* transform.up) * speed;
            soundManager.PlaySound(SoundType.OTOMATOME);
            
        }
      
       
        
        void OnTriggerEnter(Collider hitInfo){
           PlayerLife playerLife = hitInfo.GetComponent<PlayerLife>();
            if(playerLife != null){
                playerLife.TakeDamage(damage);
            
              }

         
           Destroy(gameObject);
        }
   
    }
}
