using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class BossLife : MonoBehaviour
    {
        [SerializeField]float life;
        
        public float maxLife;

        public UnityEngine.UI.Image fillBar;
        public GameObject bossBar;
    

        public GameObject deathEffect;

        public ParticleSystem vfxdeath1;
        public ParticleSystem vfxdeath2;
        public ParticleSystem vfxdeath3;
        int i = 0;
        Scene scene;
        public GameObject model;

        [SerializeField] private GameObject flashEffect;
        void Start()
        {
            life = maxLife;

            
        }

        bool flashonoff = true;
        int flashstop;

        public void TakeDamage(int damage)
        {
           
            life -= damage;
            FlashEffect();
            if (life <= 0)
            {
                WinCondition.i = 3;

                Score.scoreValue += 10000 * EnemyLife.multiplier;
                Die();

            }


        }
        void Update()
        {
            Vector2 pos = transform.position;
            if (pos.y < 6 )
            {
              bossBar.SetActive(true);
            }

         if (Input.GetKeyDown(KeyCode.F4))
         {
            life = 0;
         }
            LifeBar();
        }
        public void LifeBar()
        {

            {
                fillBar.fillAmount = life / maxLife;
               

            }
        }

        public void Die()
        {
           Instantiate(deathEffect, transform.position, Quaternion.identity);
           Instantiate(vfxdeath1, transform.position, Quaternion.identity);
           Instantiate(vfxdeath2, transform.position, Quaternion.identity);
           soundManager.PlaySound(SoundType.BOSSEXPLOSION1);
           soundManager.PlaySound(SoundType.BOSSEXPLOSION2);
            SpawnEnemyLevel2.bossInScreen = null;
            
            Destroy(gameObject);

        }

       void FlashEffect()
        {

            InvokeRepeating("Flash", 0f, 0.02f);

        }

        void Flash()
        {

            if (flashonoff)
            {
                flashEffect.SetActive(false);
                flashonoff = false;
                flashstop++;
            }
            else
            {
                flashEffect.SetActive(true);
                flashonoff = true;

            }
            if (flashstop >= 2f)
            {

                CancelInvoke("Flash");
                flashEffect.SetActive(false);
                flashstop = 0;

            }
        

        }
    }
}
