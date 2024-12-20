using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class Weapon : MonoBehaviour
    {
        public Transform[] firePoints;
        public GameObject[] shootPrefab;

        public int damage;
       public static int i = 0;
       public static int j = 0;
        public float powerUpTimer = 10f;
        public float distorcionTimer = 0;
        //  public GameObject muzzlePrefab;
        float fireTimer = 0;
        public static float fireRate = 0.1f;

        public GameObject muzzleVFX;
       


        void Start()
        {
           
        }
        void Update()
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireRate && (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) 
            || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))) 
            {

                Shoot();
                fireTimer = 0f;
                
            }
           
        }

        public void Shoot()
        {
            GameObject shoot = shootPrefab[i];
            
            if (ChorusPowerUp.active == false)
            {
                Instantiate(shoot, firePoints[0].position, transform.rotation);
            }
            else if(ChorusPowerUp.active == true)
            {
                Instantiate(shoot, firePoints[1].position, transform.rotation);
                Instantiate(shoot, firePoints[2].position, transform.rotation);
            }
          
            Instantiate(muzzleVFX, transform);
        }

      
    }
}
