using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject[] shootPrefab;

        public int damage;
        int i = 0;
        public float powerUpTimer = 10f;
        public float distorcionTimer = 0;
        //  public GameObject muzzlePrefab;

        public GameObject muzzleVFX;



        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {

                Shoot();
                
            }
            if (i == 1)
            {
                distorcionTimer += Time.deltaTime;
                if (distorcionTimer >= powerUpTimer)
                {
                    distorcionTimer = 0;
                    i = 0;
                }

            }
        }

        public void Shoot()
        {
            GameObject shoot = shootPrefab[i];
            Instantiate(shoot, firePoint.position, transform.rotation);
            Instantiate(muzzleVFX, transform);
        }

        public void DistorcionPowerUp()
        {
            i = 1;
        }
    }
}
