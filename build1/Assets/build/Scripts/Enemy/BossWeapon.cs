using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace MetalRay
{
    public class BossWeapon : MonoBehaviour
    {
        public Transform firePoint;
        
        public GameObject[] shootPrefabs;
         GameObject shootPrefab;
         int i;
        public float fireTime;
        public static bool shootOn;
       
        public float fireRate;

        void Start()
        {
            enabled = false;
        }
        void Update()
        {
           
            fireTime += Time.deltaTime;
            if (fireTime >= fireRate)
            {

                EnemyShoot();
                fireTime = 0f;
            }

        
        }
        void EnemyShoot()
        {
            int percent = Random.Range(0, 100);
            if (percent <= 100 && percent > 70)
            {
                i = 0;
            }else if (percent <= 70 && percent > 40)
            {
              i = 1;
            }
            else if (percent <= 40 && percent >20 )
            {
                i = 2;
            }
            //else if (percent <= 20 && percent > 0)
           // {
            //    shootPrefab = shootPrefabs[3];
            //}
            Instantiate(shootPrefabs[i], firePoint.position, transform.rotation);

        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("shootOn"))
            {
                ShootOn();
            }
        }

        public void ShootOn()
        {
            enabled = true;
        }

    }
}
