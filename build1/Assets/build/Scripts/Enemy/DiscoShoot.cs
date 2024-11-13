using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class DiscoShoot : MonoBehaviour
    {
        public float speed = 15f;
        public Rigidbody rb;
        public int damage = 40;
        public GameObject impactEfect;

        public float timeDestroy;
        float timer;
        public GameObject firePoint;
        

      
        void Start(){
            rb.velocity = (-1* transform.up) * speed;
            soundManager.PlaySound(SoundType.DISCO);
           
        }
        void Updtade(){
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer == 0)
            {
       //         Instantiate(firePoint,transform.position, Quaternion.);
            }
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
