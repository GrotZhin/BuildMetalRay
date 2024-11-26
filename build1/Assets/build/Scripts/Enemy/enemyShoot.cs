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
        public GameObject impactEfect;
        float time = 0f;

        
        

      
        void Start(){
            rb.velocity = (-1* transform.up) * speed;
            soundManager.PlaySound(SoundType.OTOMATOME);
            
        }
        void Update()
        {
            if(ReverbPowerUp.active == true)
            Debug.Log(ReverbPowerUp.active);
            {
                time += Time.deltaTime;
                Debug.Log(time);
                if (time >= 10f)
                {
                    speed = 3;
                    ReverbPowerUp.active = false;
                    Debug.Log(ReverbPowerUp.active);
                    time = 0;
                } 
                
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
