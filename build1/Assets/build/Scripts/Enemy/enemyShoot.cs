using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class enemyShoot : MonoBehaviour
    {
        public float speed = 15f;
        public Rigidbody rb;
        public int damage = 40;
        public GameObject impactEfect;

        public float timeDestroy;
        

      
        void Start(){
            rb.velocity = (-1* transform.up) * speed;
            Destroy(this.gameObject, timeDestroy);
        }
       
        
        void OnTriggerEnter(Collider hitInfo){
           PlayerLife playerLife = hitInfo.GetComponent<PlayerLife>();
            if(playerLife != null){
                playerLife.TakeDamage(damage);
                

              }

           Instantiate(impactEfect, transform.position, transform.rotation);
           Destroy(gameObject);
        }
   
    }
}
