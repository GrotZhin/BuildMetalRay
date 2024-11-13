using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace MetalRay
{
    public class Shoot : MonoBehaviour
    {
        public float speed = 20f;
        public Rigidbody rb;
        public Transform parent;

        public float timeDestroy = 0f;
        public int damage = 40;
        public GameObject impactEfect;
        public GameObject muzzlePrefab;

        Weapon weapon;

        void Start()
        {
            weapon = GetComponent<Weapon>();
            rb.velocity = transform.up * speed;
            Destroy(this.gameObject, timeDestroy);
        

            if (muzzlePrefab != null)
            {
                GameObject muzzleVFX = Instantiate(muzzlePrefab, transform.position, quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(parent);


                Destroy(muzzleVFX, 0.25f);

            }
        }

        void OnTriggerEnter(Collider hitInfo)
        {
            
            EnemyLife enemyLife = hitInfo.GetComponent<EnemyLife>();
            SubBossLife subBossLife = hitInfo.GetComponent<SubBossLife>();
            if (enemyLife != null)
            {
                enemyLife.TakeDamage(damage);
                
            }
            else if (subBossLife != null)
            {
                
                subBossLife.TakeDamage(damage);
            }

            Instantiate(impactEfect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }
}


