using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class RotativeShoot : MonoBehaviour
    {

        public float bltlife = 1f;
        public int damage = 10;
        public float spd= 15f;
        public float Rotation = 0f;
        public GameObject impactEfect;
     
        public Vector2 Spawnpoint;
        
        public float timer= 0f;
        void Start()
        {
         Spawnpoint = new Vector2(transform.position.x,transform.position.y );
        }

        // Update is called once per frame
        void Update()
        {
        
            if(timer > bltlife) Destroy(this.gameObject);
            timer += Time.deltaTime;
            transform.position = Moviment(timer);

        }
        public Vector2 Moviment(float timer)
        {
            float x = timer* spd * transform.right.x;
            float y = timer* spd * transform.right.y;
            return new Vector2(x+Spawnpoint.x,y+Spawnpoint.y);
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
