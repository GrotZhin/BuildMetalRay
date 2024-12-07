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
        public Transform[] firePoint;

        public Animator animator;
        public Animator flashanimator;

        public GameObject[] shootPrefabs;
        GameObject shootPrefab;
        GameObject turret;
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
                 Attack1();


            }
             else if (percent <= 70 && percent > 40)
            {
                Attack2();
                
            }
            else if (percent <= 40 && percent > 20)
            {
                Attack3();
            }
            else if (percent <= 20 && percent > 0)
            {
               Turret();
            }
           
           
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

        public void Attack1(){

            animator.Play("attack1");
            flashanimator.Play("attack1");
                Instantiate(shootPrefabs[0], firePoint[1].position, transform.rotation);
                Instantiate(shootPrefabs[0], firePoint[0].position, transform.rotation);
        }
        public void Attack2(){
            animator.Play("attack2");
            flashanimator.Play("attack2");
            for (int i = 0; i <= 7; i++)
                {
                 
                 Instantiate(shootPrefabs[1], firePoint[i].position, transform.rotation);
                }
        }

        public void Attack3(){
             animator.Play("attack3");
             flashanimator.Play("attack3");
             Instantiate(shootPrefabs[2], firePoint[1].position, transform.rotation);

                Instantiate(shootPrefabs[2], firePoint[0].position, transform.rotation);
        }
        public void Turret(){

          

               if (turret == null)
                {
                    turret = Instantiate(shootPrefabs[3], firePoint[8].position, transform.rotation);
                    
                }

        }

    }
}
