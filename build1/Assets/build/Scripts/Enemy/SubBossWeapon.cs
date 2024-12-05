using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace MetalRay
{
    public class SubBossWeapon : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject firePoint1;
        public GameObject shootPrefab;
        public float fireTime;
        public static bool shootOn;
       
        public float fireRate;

        void Start()
        {
            enabled = false;
        }
        void Update()
        {
            if (shootOn == true){
            fireTime += Time.deltaTime;
            if (fireTime >= fireRate)
            {

                EnemyShoot();
                fireTime = 0f;
            }

        }
        }
        void EnemyShoot()
        {
            
            Instantiate(shootPrefab, firePoint.position, transform.rotation);

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
